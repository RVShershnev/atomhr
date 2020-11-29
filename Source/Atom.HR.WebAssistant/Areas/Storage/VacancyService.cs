using Atom.HR.Models;
using Newtonsoft.Json;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Atom.HR.WebAssistant.Areas.Storage
{
    public class VacancyService
    {
        protected IDocumentSession session { get; private set; } = StoreHolder.Store.OpenSession();
        
        public IDocumentSession GetSession()
        {
            return StoreHolder.Store.OpenSession();
        }
        public async void CreateVacancy(Vacancy vacancy)
        {
            using (IDocumentSession session = StoreHolder.Store.OpenSession())
            {
                vacancy.CreatedTime = DateTime.Now;
                session.Store(vacancy);
                session.SaveChanges();
            }
        }

        public async Task<List<Vacancy>> GetAllVacancy()
        {
            using (IDocumentSession session = StoreHolder.Store.OpenSession())
            {
                return session.Advanced.LoadStartingWith<Vacancy>("Vacancies", null, 0, 128).ToList();
            }
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            using (IDocumentSession session = StoreHolder.Store.OpenSession())
            {
                return session.Advanced.LoadStartingWith<Skill>("Skills", null, 0, 300).ToList();
            }
        }
    }
}
