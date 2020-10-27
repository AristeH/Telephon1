using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telephon.Commands
{

    class wsSendCommand
    {
        public DelegateCommand WSConnect { get; private set; }
        public void wsSendCommandExecute(string parameter)
        {
            //   ws = new WebsocketClient();
            //   ws.initWebSocketClient("ws://127.0.0.1:8080/telephon");
            //    ws.ds = Dispatcher.CurrentDispatcher; ;
            Char delimiter = ',';
            String[] substrings = parameter.Split(delimiter);
          //  mess sendmes = new mess();
          //  sendmes.Action = substrings[0];
          //  sendmes.parameters = substrings[1].Split(';');
          //  ws.sendMessage(sendmes);
        }
        public bool wsSendCommandExecute()
        {
         //  if (ws == null)
         //  {
                return true;
         //   }
          //  return !ws.is_connected;
        }
    }
}
