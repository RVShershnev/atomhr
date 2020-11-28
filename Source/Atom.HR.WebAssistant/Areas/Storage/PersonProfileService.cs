using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atom.HR.Models;
using Atom.HR.Shared;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Queries;
using Raven.Client.Documents.Session;

namespace Atom.HR.WebAssistant.Areas.Storage
{
    public class PersonProfileService
    {        
        protected IDocumentSession session { get; private set; } = StoreHolder.Store.OpenSession();

        public IDocumentSession GetSession()
        {
            return StoreHolder.Store.OpenSession();           
        }

        public async Task<IEnumerable<PersonProfile>> GetPersonProfilesAsync()
        {
            using (session = StoreHolder.Store.OpenSession())
            {
                session.Advanced.UseOptimisticConcurrency = true;
                return session.Advanced.LoadStartingWith<PersonProfile>("PersonProfiles", null, 0, 128);
            }
        }
      
        public async void CreateOrUpdate(PersonProfile profile)
        {
            using (session = StoreHolder.Store.OpenSession())
            {
                session.Advanced.UseOptimisticConcurrency = true;
    
                // var p = session.Load<PersonProfile>($"{profile.Id}");
                //if(p != null)
                //{             
                //    session.Store(profile);                    
                //}
                //else
                //{                 
                //    session.Store(profile);
                //}
                // Apply changes
                session.Store(profile, profile.Id, null);
                session.SaveChanges();                
           }
        }
        public async Task<List<Info2>> GetTypesProfiles()
        {          
            using (session = StoreHolder.Store.OpenSession())
            {
                //var result1 = session.Advanced.LoadStartingWith<PersonProfile>("PersonProfiles", null, 0, 128);
                //var results = session.Query<PersonProfile>()
                //    .GroupBy(x => new
                //    {
                //        x.TypeCompanyRelation                 
                //    })
                //.Select(x => new Tuple<string, int>(x.Key.TypeCompanyRelation, x.Count()))
                //.ToList();

                var results1 = (from o in session.Query<PersonProfile>()
                               group o by o.TypeCompanyRelation
                               into g
                               select new Info2 { Name = g.Key, Count= g.Count() })
                               .ToList();
                
                //            var result2 = session.Query<PersonProfile>()
                //.GroupBy(x => new 
                //{ 
                //    x.TypeCompanyRelation 
                //})
                ////.Select(x => new Tuple<string, int>(x.Key, x.Count()))
                //.ToList();
       
                return results1;
            }
        }
        
        public async Task<PersonProfile> LoadAsync(string id)
        {
            using (session = StoreHolder.Store.OpenSession())
            {
                var result = session.Load<PersonProfile>(id);
                return await Task.FromResult(result);
            }
        }
    }
  
}
