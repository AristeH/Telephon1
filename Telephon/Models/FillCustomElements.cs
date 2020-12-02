using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Xml.Linq;
using Telephon.Services;
using static Telephon.Models.shapka;

namespace Telephon.Models
{
    class FillCustomElements
    {
        static public IList<ButtonForm> ButtonsFill(XElement parameters, DelegateCommand<mess> com1)
        {
            IList<ButtonForm> Buttons4 = new List<ButtonForm>();
            foreach (XElement stroca in parameters.Elements("buttonstop"))
            {
                mess sendmess = new mess
                {
                    action = "getform",
                    content = "MainForm",
                    parameters = new[] { "mainform", stroca.Element("parameters").Value },
                };
                Buttons4.Add(new ButtonForm { Name = stroca.Element("name").Value, Image = stroca.Element("image").Value, com = com1, Parameters = sendmess });
            }
            return Buttons4;
        }
        // распарсим описание полей(колонок грида), 
        // функция возвращает список полей содержащий имя, тип(или значение), роль доступа
        static public List<FieldSection> FieldsFill(XElement parameters)
        {
            var afs = new List<FieldSection>();
            foreach (XElement field in parameters.Elements("fields"))
            {
                FieldSection fs = new FieldSection();
                fs.name = field.Element("name").Value;
                fs.value = field.Element("value").Value;
                fs.tip = field.Element("tip").Value;
                fs.buttons = field.Element("buttons").Value;
                afs.Add(fs);
            }
            return afs;
        }

        static public ObservableCollection<List<FieldSection>> ShapkaFill(XElement parameters)
        {

            ObservableCollection<List<FieldSection>> stroki1 = new ObservableCollection<List<FieldSection>>();
            foreach (XElement stroca in parameters.Elements("stroki"))
            {
                List<FieldSection> afs = FieldsFill(stroca);
                stroki1.Add(afs);
            }
            return stroki1;
        }

        static public List<string> RecsFill(XElement parameters)
        {
            var recs = new List<string>();
            foreach (XElement field in parameters.Elements("Recs"))
            {
                recs.Add(field.Value);
            }
            return recs;
        }



    }
}
