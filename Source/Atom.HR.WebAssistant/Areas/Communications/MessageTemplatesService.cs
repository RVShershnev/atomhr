using Atom.HR.MessageTemplates;
using Atom.HR.Models;
using Atom.HR.WebAssistant.Areas.Storage;
using Microsoft.IdentityModel.Tokens;
using Nexmo.Api;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Atom.HR.WebAssistant.Areas.Communications
{
    public class MessageTemplatesService
    {
        protected IDocumentSession session { get; private set; } = StoreHolder.Store.OpenSession();

        public IDocumentSession GetSession()
        {
            return StoreHolder.Store.OpenSession();
        }

        public async Task<List<MessageTemplate>> GetAllMessageTemplates()
        {
            using (session = StoreHolder.Store.OpenSession())
            {
                session.Advanced.UseOptimisticConcurrency = true;
                return session.Advanced.LoadStartingWith<MessageTemplate>("MessageTemplates", null, 0, 128).ToList();
            }
        }
        
        public async Task<SMS.SMSResponse> SendInvite(PersonProfile profile, bool telephone = true, bool email = true)
        {
            string messegeText = "";
            if (telephone)
            {
                using (session = StoreHolder.Store.OpenSession())
                {
                    session.Advanced.UseOptimisticConcurrency = true;
                    List<MessageTemplate> employees = session
                        .Query<MessageTemplate>()
                        .Where(x => x.Language == "Английский")
                        .Where(x => x.Sex == profile.Sex.ToString())
                        .ToList();
                    var i = new Random().Next(0, employees.Count);
                    messegeText = GetMessage(profile, employees.Skip(i).First());
                }
                var client = new Client(creds: new Nexmo.Api.Request.Credentials
                {
                    ApiKey = "42b78bc4",
                    ApiSecret = "Ze59JrtW8fePjpgW"
                });
                var results = client.SMS.Send(request: new SMS.SMSRequest
                {
                    from = "Vonage APIs",
                    to = profile.Telephone.Replace("-", ""),
                    text = messegeText
                });
                return results;
            }
            if (email)
            {
                // отправка по enail
            }
            return new SMS.SMSResponse();
        }


        private string GetMessage(PersonProfile person, MessageTemplate template)
        {
            TemplateExercise booltemp = new TemplateExercise();
            booltemp.Template = template.Text;

            if(person.ChallengeId == null || person.ChallengeId =="")
            {
                person.ChallengeId = "https://github.com/RVShershnev/atomhr";
            }

            booltemp.Variations = new List<(string, string)>();
            booltemp.Variations.Add(new("$(N)", person.Name));
            booltemp.Variations.Add(new("$(C)", person.ChallengeId));
                      
            string pattern = @"\$\(\S\)";
            var regex = new Regex(pattern);
            MatchCollection matchedAuthors = regex.Matches(booltemp.Template);
            var newTask = booltemp.Template;          
            foreach (var item in matchedAuthors)
            {
                var rep = booltemp.Variations.Where(x => x.Item1 == item.ToString()).Select(x => x);               
                var trep = rep.First();
                newTask = newTask.Replace(item.ToString(), trep.Item2);        
            }
            return newTask;
        }
        public class TemplateExercise
        {
            public string Text;
            public string Theme;
            public string Purpose;
            public string Template;
            public List<(string, string)> Variations;
        }
    }
}
