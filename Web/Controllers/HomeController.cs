using Common;
using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using BLL;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var test = UnityHelper.Instance.Resolve<ITest>("Test");
            //var res = test.SayHello();
            ////var grades = UnityHelper.Instance.Resolve(typeof(IGradeBLL), "gradeBLL");
            //IGradeBLL gradeBll =UnityHelper.Instance.Resolve<IGradeBLL>();
            //var grades = gradeBll.LoadEntities(u => u.Discount > 20);

            //IProjectBLL iProjectBLL = new ProjectBLL();
            //var por = iProjectBLL.ProjectList();
            //var por2 = iProjectBLL.ProjectList2();
            //var grades = iProjectBLL.

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}