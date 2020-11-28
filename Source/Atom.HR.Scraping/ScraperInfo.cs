using System;
using System.Collections.Generic;
using System.Text;

namespace Atom.HR.Scraping
{
    public class ScraperInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public byte[] Image { get; set; }
        public bool Status { get; set; }
    }
}
