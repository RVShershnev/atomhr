using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.HR.Scraping.Hhru
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Specialization
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool laboring { get; set; }
    }

    public class MyArray1
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Specialization> specializations { get; set; }
    }

    public class Specializations
    {
        public List<MyArray> MyArray { get; set; }
    }


}
