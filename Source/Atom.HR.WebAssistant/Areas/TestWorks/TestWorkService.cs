using Atom.HR.Models;
using Atom.HR.WebAssistant.Areas.Storage;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atom.HR.WebAssistant.Areas.TestWorks
{
    public class TestWorkService
    {
        protected IDocumentSession session { get; private set; } = StoreHolder.Store.OpenSession();

        public IDocumentSession GetSession()
        {
            return StoreHolder.Store.OpenSession();
        }

        public async Task<List<TestWork>> GetAllTestWork()
        {
            using (session = StoreHolder.Store.OpenSession())
            {
                session.Advanced.UseOptimisticConcurrency = true;
                return session.Advanced.LoadStartingWith<TestWork>("TestWorks", null, 0, 128).ToList();
            }
        }

        public void SendTestWork()
        {

        }
    }
}
