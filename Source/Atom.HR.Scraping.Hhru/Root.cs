using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.HR.Scraping.Hhru
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Area2
    {
        public string id { get; set; }
        public string parent_id { get; set; }
        public string name { get; set; }
        public List<object> areas { get; set; }
    }

    public class Area
    {
        public string id { get; set; }
        public string parent_id { get; set; }
        public string name { get; set; }
        public List<Area2> areas { get; set; }
    }

    public class MyArray
    {
        public string id { get; set; }
        public object parent_id { get; set; }
        public string name { get; set; }
        public List<Area> areas { get; set; }
    }

    public class Country
    {
        public List<MyArray> MyArray { get; set; }
    }

}
