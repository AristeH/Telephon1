using System;
using WebSocket4Net;
using Newtonsoft.Json;

using System.Windows.Threading;
using System.Windows;
using System.Windows.Media;
using Telephon.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Telephon.Services
{
    public struct mess
    {
        public string action;      // функция
        public string content;     // доп информация к действию
        public string sender;      // оправитель
        public string recipient;   // получатель

        public string []parameters; // праметры к функция
    }
    class WebsocketClient
    {
        public WebSocket websocket;
        public bool is_connected = false;
        public Dispatcher ds; //главное окно приложения  
        public mess sendmes = new mess();

        public event Action<string> Anounesment;
        //Создадим событие для отработки получения сообщения от сервера
        public void MessageReceived(string str)
        {
            if (Anounesment != null) { Anounesment(str); } // Вызов события.
        }
        public void initWebSocketClient(String serverURL)
        {
            if (serverURL == "")
            {
                //   textBox2.Text += "Не задана строка подключения\n";
            }
            else
            {
                websocket = new WebSocket(serverURL);
                websocket.Closed += new EventHandler(websocket_Closed);
                websocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(websocket_Error);
                websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
                websocket.Opened += new EventHandler(websocket_Opened);
                websocket.Open();
            }
        }

        public void websocket_Opened(object sender, EventArgs e)
        {
            is_connected = true;
        }

        public void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            MessageReceived("ошибка");
        }

        public void websocket_Closed(object sender, EventArgs e)
        {
            is_connected = false;
        }

        // Получено сообщение необходимо обаработать его
        public void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
               MessageReceived(e.Message);
          
        }

        public void sendMessage(mess Message)
        {
            if (is_connected)
            {
                string json = JsonConvert.SerializeObject(Message);
                websocket.Send(json);
            }
        }


    }
}



