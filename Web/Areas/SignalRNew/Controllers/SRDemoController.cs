using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.SignalRNew.Controllers
{
    public class SRDemoController : Controller
    {
        // GET: SignalRNew/SRDemo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SRSend()
        {
            return View();
        }

    }
}