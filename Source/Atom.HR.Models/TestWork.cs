using System;
using System.Collections.Generic;

namespace Atom.HR.Models
{
    [Serializable]
    public class TestWork
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public List<string> NameSkills { get; set; }
        public string Type { get; set; }
    }
}
