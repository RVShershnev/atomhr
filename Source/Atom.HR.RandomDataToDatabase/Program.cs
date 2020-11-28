using Atom.HR.Models;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
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

                }) ;

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
