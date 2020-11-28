using Atom.HR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.HR.Professions
{
    [Serializable]
    public class ProfessionInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Sex { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }             
        Dictionary<Skill, object> Skills { get; set; }
    }
}
