using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
namespace BLL.Areas.CssJquery
{
    public class CsProgressDemoBLL :Hub
    {
        public void SendSignalRDome(string sUser, string sMsg)
        {
            Clients.All.Msg(sUser,sMsg);
        }
    }
}
