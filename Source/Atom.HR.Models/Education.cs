using System;

namespace Atom.HR.Models
{
    [Serializable]
    public class Education
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public string Summary { get; set; }
    }
}
