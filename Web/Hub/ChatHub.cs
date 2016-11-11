﻿using System;
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
            Clients.All.hello(name, message);
        }
    }
}