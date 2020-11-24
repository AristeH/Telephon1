using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml.Linq;
using Telephon.Models;
using Telephon.Services;
using static Telephon.Models.shapka;

namespace Telephon.ViewModels
{
    class VM_MainWindow : ViewModelBase
    {
        public WebsocketClient ws;
        public DelegateCommand<mess> wsSendCommand { get; private set; }
        public IList<ButtonForm> ButtonsTop { get; set; } = new List<ButtonForm>();
        public IList<ButtonForm> ButtonsDown { get; set; }
        public List<List<FieldSection>> stroki { get; set; }
        public grid grid { get; set; }
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
            string[] mass =  message.Split(";:");
            foreach (string me in mass)
                switch (me)
                {
                    case "getform":
                        XDocument xdoc = XDocument.Parse(mass[1]);
                        ButtonsTop.Clear();
                        ButtonsTop = FillCustomElements.ButtonsFill( xdoc.Element("UserForm"), wsSendCommand); 
                        stroki = FillCustomElements.ShapkaFill(xdoc.Element("UserForm"));
                        grid =  new grid(xdoc.Element("UserForm"));   
                        break;


            } 
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
            ButtonsDown = new List<ButtonForm>();
            ButtonsDown.Add(new ButtonForm { Name = "Подключить", com = wsSendCommand, Parameters = sendmess });
        }
    }
}
