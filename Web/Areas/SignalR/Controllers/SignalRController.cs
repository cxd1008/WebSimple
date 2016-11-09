using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Web.Areas.SignalR.Controllers
{
    public class SignalRController : Controller
    {
        public ActionResult SignalRDemo()
        {
            return View();
        }
    }
}
