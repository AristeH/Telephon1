using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Telephon.Models;
using Telephon.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using Telephon.Services;
using System.Windows.Threading;
using Telephon.Views;
using System.Xml.Linq;
using System.ComponentModel;
using static Telephon.Models.shapka;

namespace Telephon.ViewModels
{
    class VM_MainWindow : ViewModelBase
    {

          

        public WebsocketClient ws;
        public DelegateCommand<mess> wsSendCommand { get; private set; }
        public IList<ButtonForm> ButtonsTop { get; set; } = new List<ButtonForm>();
          public IList<ButtonForm> ButtonsDown { get; set; } = new List<ButtonForm>();
        public List<arrayFieldSection> stroki { get; set; } = new List<arrayFieldSection>();

        public string Title { get; set; }
        public string EditBox { get; set; }
        

        void wsSendCommandExecute(mess sendmes)
        {

            if (!ws.is_connected)
            {
                ws.initWebSocketClient("ws://127.0.0.1:8080/telephon");
                ws.ds = Dispatcher.CurrentDispatcher;
            }
            ws.sendMessage(sendmes);
        }
        bool wsSendCommandCanExecute(mess sendmes)
        {
            return true;
        }

        public void Show_String(string message) // Обработчик события соответствующий сигнатуре делегата. На него мы должны добавить ссылку.
        {
            EditBox = message;
          
           string[] mass =  message.Split(";");
            IList<ButtonForm> Buttons4 = new List<ButtonForm>();
            XDocument xdoc = XDocument.Parse(mass[1]);

                foreach (XElement stroca in xdoc.Element("listform").Elements("buttons"))
                {
                Buttons4.Add(new ButtonForm { Name = stroca.Element("name").Value, com = wsSendCommand });
                }
            ButtonsTop.Clear();
        ButtonsTop = Buttons4;
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
            stroki = stroki1;

        }

        public VM_MainWindow()
        {
            ws = new WebsocketClient();

           
            ws.Anounesment += Show_String; // Добавляем ссылку на метод в событие.
            //ws.Announce("Вызов обработчика события успешен"); // Вызываем событие через метод Announce.
            ws.initWebSocketClient("ws://127.0.0.1:8080/telephon");
            ws.ds = Dispatcher.CurrentDispatcher;
            wsSendCommand = new DelegateCommand<mess>(wsSendCommandExecute, wsSendCommandCanExecute);
            Title = "Телефоны";
            mess sendmess = new mess
            {
                action = "getform",
                content = "login",
                parameters = new[] { "", "" },
            };
    
            ButtonsTop.Add(new ButtonForm { Name = "Ntcn" });
            ButtonsTop.Add(new ButtonForm { Name = "Ntcn3" });
           // ButtonsDown.ElementsButtonsForm.Add(new ButtonForm { Name = "Ntcn45", com = wsSendCommand, Parameters = sendmess });
          ButtonsDown.Add(new ButtonForm { Name = "Ntcn46", com = wsSendCommand, Parameters = sendmess });
            //   ElementsButtonsForm
            //    ElementsButtonsForm1.Add(new ButtonForm { Name = "Ntcn1", });

        }
    }
}
