using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

//namespace Web.Areas.SignalRNew.Cs
namespace Web
{
    public class ChatHub : Hub
    {
        public void Hello(string name, string message)
        {
            Clients.All.helloBack(name, message);
            
            //Clients.Caller.hello(name, message);//只发给自己
            //发送给某人
            //Clients.Client("a").receivePrivateMessage("a", name, message);
        }
    }
}