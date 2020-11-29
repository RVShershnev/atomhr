using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Atom.HR.WebAssistant.Areas.Storage
{
    public class StoreHolder
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {           
            X509Certificate2 clientCertificate = new X509Certificate2(@"hr-dev.atom.client.certificate.pfx");
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
                Database = "hrdb"
                // Initialize the Document Store
            }.Initialize();
            return store;


        }
    }
}
