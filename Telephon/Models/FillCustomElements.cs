using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Telephon.Services;
using static Telephon.Models.shapka;

namespace Telephon.Models
{
    class FillCustomElements
    {
        static public IList<ButtonForm> ButtonsFill(string parameters, DelegateCommand<mess> com1)
        {
            IList<ButtonForm> Buttons4 = new List<ButtonForm>();
            XDocument xdoc = XDocument.Parse(parameters);

            foreach (XElement stroca in xdoc.Element("listform").Elements("buttons"))
            {
                Buttons4.Add(new ButtonForm { Name = stroca.Element("name").Value, com = com1 });
            }
            return Buttons4;
        }

        static public List<arrayFieldSection> ShapkaFill(string parameters)
        { 
            XDocument xdoc = XDocument.Parse(parameters);
            List<arrayFieldSection> stroki1 = new List<arrayFieldSection>();
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
                stroki1.Add(afs);
            }
            return stroki1;

        }
    }
}
