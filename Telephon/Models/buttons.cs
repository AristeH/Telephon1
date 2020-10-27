using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Telephon.Services;

namespace Telephon.Models
{

    public class ButtonForm
    {
        public string Name { get; set; }
        public mess Parameters { get; set; }
        public string Image { get; set; }
        public DelegateCommand<mess> com { get; set; }
    }

    //public Buttons(string parameters, DelegateCommand<mess> com1)
    //{
    //    XDocument xdoc = XDocument.Parse(parameters);

    //    foreach (XElement stroca in xdoc.Element("listform").Elements("buttons"))
    //    {
    //        ElementsButtonsForm.Add(new ButtonForm { Name = stroca.Element("name").Value, com = com1 });
    //    }
    //}
    
}

