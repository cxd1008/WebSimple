using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;

namespace Web
{
    public class BookingHub : Hub
    {
        public void processcount(string sCount)
        {

            for (int i = 1; i <= 100; i++)
            {
                Clients.Caller.updatecount(i);
                Thread.Sleep(200);
            }
        }
    }
}