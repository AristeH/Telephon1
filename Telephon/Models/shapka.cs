using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Telephon.Models
{
    public class shapka
    {
        public struct arrayFieldSection
        {
            public List<FieldSection> fields { get; set; }
        }
        public class FieldSection
        {
            public string name { get; set; }
            public string value { get; set; }
            public string tip { get; set; }
            public string buttons { get; set; }
        }
        public string name { get; set; }
        public string title { get; set; }

        public List<arrayFieldSection> stroki { get; set; }
    }
}
