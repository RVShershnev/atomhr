using Atom.HR.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.HR.Models
{
    [Serializable]
    public class TeamVacancy
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public ProfessionInfo Profession { get; set; }
        public Dictionary<TestWork, int> TestWorks { get; set; }

    }
}
