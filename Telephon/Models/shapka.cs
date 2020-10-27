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
        public struct FieldSection
        {
            public string name { get; set; }
            public string value { get; set; }
            public string buttons { get; set; }
        }
        public string name { get; set; }
        public string title { get; set; }

        public List<arrayFieldSection> stroki { get; set; }


        public shapka(string parameters)
        {

            stroki = new List<arrayFieldSection>();
            XDocument xdoc = XDocument.Parse(parameters);
            name = xdoc.Element("listform").Element("name").Value;
            title = xdoc.Element("listform").Element("title").Value;
            foreach (XElement stroca in xdoc.Element("listform").Elements("stroki"))
            {
                arrayFieldSection afs = new arrayFieldSection();
                afs.fields = new List<FieldSection>();
                foreach (XElement field in stroca.Elements("fields"))
                {
                    FieldSection fs = new FieldSection();
                    fs.name = field.Element("name").Value;
                    fs.value = field.Element("value").Value;
                    fs.buttons = field.Element("buttons").Value;
                    afs.fields.Add(fs);
                }
                stroki.Add(afs);
            }
        }

    }


}
