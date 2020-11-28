using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.HR.Models
{
    [Serializable]
    public class Skill
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
    }
}
