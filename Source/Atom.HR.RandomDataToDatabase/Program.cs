using Atom.HR.MessageTemplates;
using Atom.HR.Models;
using Newtonsoft.Json;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Atom.HR.RandomDataToDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();
            var store = CreateStore();


            PutSkill(store);
            // PutResume(store);
            //PutMessageTemplate(store);

        }
        public static void PutResume(IDocumentStore store)
        {
            using (IDocumentSession session = store.OpenSession("hrdb"))
            {
                // generate Id automatically
                session.Store(new PersonProfile
                {
                    Name = "Роман Шершнев",
                    Birthday = new DateTime(1994, 8, 23),
                    Childrens = 0,
                    HasCar = true,
                    DriveCard = "B",
                    IsMarried = false,
                    Sex = Sex.Male,
                    Сitizenship = "РФ",
                    Situated = "Обнинск",
                    TypeCompanyRelation = "Участник"

                });

                // generate Id automatically
                session.Store(new PersonProfile
                {
                    Name = "Анастасия Теплякова",
                    Birthday = new DateTime(1997, 1, 1),
                    Childrens = 0,
                    HasCar = true,
                    DriveCard = "B",
                    IsMarried = false,
                    Sex = Sex.Female,
                    Сitizenship = "РФ",
                    Situated = "Обнинск",
                    TypeCompanyRelation = "Партнер"
                });

                // generate Id automatically
                session.Store(new PersonProfile
                {
                    Name = "Дмитрий Распопов",
                    Birthday = new DateTime(1996, 3, 13),
                    Childrens = 0,
                    HasCar = true,
                    DriveCard = "B",
                    IsMarried = false,
                    Sex = Sex.Male,
                    Сitizenship = "РФ",
                    Situated = "Обнинск",
                    TypeCompanyRelation = "Партнер"
                });

                // generate Id automatically
                session.Store(new PersonProfile
                {
                    Name = "Александр Неметулаев",
                    Birthday = new DateTime(1996, 2, 11),
                    Childrens = 0,
                    HasCar = false,
                    DriveCard = "A",
                    IsMarried = false,
                    Sex = Sex.Male,
                    Сitizenship = "РФ",
                    Situated = "Обнинск",
                    TypeCompanyRelation = "Пусто"
                });

                // send all pending operations to server, in this case only `Put` operation
                session.SaveChanges();


            }
        }
        public static void PutMessageTemplate(IDocumentStore store)
        {
            using (IDocumentSession session = store.OpenSession("hrdb"))
            {
                var list = new List<MessageTemplate>()
                {
                new MessageTemplate()
                {
                    Name = "Hi",
                    Language = "Английский",
                    Key = "Приветствие",
                    Channel = "Телефон",
                    Sex = Sex.Any.ToString(),
                    Text = "Hi, $(N). How are you?"
                },
               new MessageTemplate()
                {
                    Name = "Здравствуйте1",
                    Language = "Английский",
                    Key = "Приветствие",
                    Channel = "Телефон",
                    Sex = Sex.Any.ToString(),
                    Text = "Здравствуйте, $(N). Приглашаем Вас на встречу."
                }, new MessageTemplates.MessageTemplate()
                {
                    Name = "Приглашаю1",
                    Language = "Английский",
                    Key = "Приветствие",
                    Channel = "Телефон",
                    Sex = Sex.Any.ToString(),
                    Text = "Привет, $(N). Приглашаем Вас на встречу."
                },
                new MessageTemplates.MessageTemplate()
                {
                    Name = "Приглашаю",
                    Language = "Английский",
                    Key = "Приветствие",
                    Channel = "Телефон",
                    Sex = Sex.Any.ToString(),
                    Text = "Здравствуйте, $(N). Приглашаем Вас на встречу."
                   }
                };

                foreach (var item in list)
                {                    
                    session.Store(item);
                }           
                // send all pending operations to server, in this case only `Put` operation
                session.SaveChanges();
            }
        }

        public static void PutSkill(IDocumentStore store)
        {
            var Rand = new Random();
         
            using (IDocumentSession session = store.OpenSession("hrdb"))
            {
                var skill = (File.ReadAllText("skills.json"));
                var sp = @"\"", \""";
                var ttrrr = skill.Remove(0, 4);
                skill = ttrrr.Remove(ttrrr.Length - 4, 4);
                var tt = skill.Split(sp);
                {
                    for (var i = 0; i < tt.Length; i++)
                    {
                        var n = Rand.Next(1, 12);
                        var date = new DateTime(DateTime.Now.Year, n, DateTime.Now.Day);
                        var fgg = new Skill() { Name = tt[i], DateTimeCreated = date };
                      
                        session.Store(fgg);
                    }
                }
                // send all pending operations to server, in this case only `Put` operation
                session.SaveChanges();
            }
        }


        private static IDocumentStore CreateStore()
        {
            X509Certificate2 clientCertificate = new X509Certificate2(@"C:\Users\rvs\Desktop\hr-dev.atom.client.certificate (1)\hr-dev.atom.client.certificate.pfx");
            IDocumentStore store = new DocumentStore()
            {
                // Define the cluster node URLs (required)
                Urls = new[] { "https://a.hr-dev.atom.ravendb.cloud", 
                           /*some additional nodes of this cluster*/ },
                // Set conventions as necessary (optional)
                Conventions =
            {
                MaxNumberOfRequestsPerSession = 10,
                UseOptimisticConcurrency = true
            },
                // Define a default database (optional)
                Certificate = clientCertificate,
                Database = "WebAssistantDBStore"
                // Initialize the Document Store
            }.Initialize();
            return store;


            //IDocumentStore store = new DocumentStore()
            //{
            //    // Define the cluster node URLs (required)
            //    Urls = new[] { "127.0.0.1:6506", 
            //               /*some additional nodes of this cluster*/ },
            //    // Set conventions as necessary (optional)
            //    Conventions =
            //{
            //    MaxNumberOfRequestsPerSession = 10,
            //    UseOptimisticConcurrency = true
            //},
            //    // Define a default database (optional)
            //    Certificate = clientCertificate,
            //    Database = "WebAssistantDBStore"                
            //    // Initialize the Document Store
            //}.Initialize();

            //return store;

        }
    }
}
