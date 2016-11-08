using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.CssJquery.Controllers
{
    public class ProgressDemoController : Controller
    {
        /// <summary>
        /// 默认页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProgressDemo()
        {
            return View();
        }
        public ActionResult CssDemo()
        {
            return View();
        }

         private static  Dictionary<Guid, int> myDictionary = new Dictionary<Guid, int>();

        public ActionResult setProgressDemoMain(Guid myGuid)
        {
            Action<Guid> myAction = setTimer;
            myAction.BeginInvoke(myGuid,null, null);
            return Content("a");
        }

        private void setTimer(Guid myGuid)
        {
            for (int i = 0; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(90);
                myDictionary[myGuid] = i;
                if (i==100)
                {
                    myDictionary.Remove(myGuid);
                }
            }
        }
        public ActionResult getTimer(Guid myGuid)
        {
            if (myDictionary.ContainsKey(myGuid))
            {
                return Content(myDictionary[myGuid].ToString());
            }
            return Content("100");
        }
	}
}