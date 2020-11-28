using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.HR.Models
{
    public class Challenge
    {
        public string ChallengeId { get; set; }
        public List<Criterion> Criteria { get; set; }
    }
    public class Criterion
    {
        public string TestWorkId { get; set; }
        public string Name { get; set; }
        public Type TypeValue { get; set; }
        public object Value { get; set; }
    }

}
