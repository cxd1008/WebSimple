using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.CssJquery.Controllers
{
    public class DivDemoController : Controller
    {
        
        //我的第一个项目1234
        public ActionResult WebDemo()
        {
            return View();
        }
        //这是一个我的修改，看看提交是什么样子的。
        public ActionResult WebDemoBoot()
        {
            return View();
        }
        public ActionResult SnowDemo()
        {
            return View();
        }
        public ActionResult LunBoDemo()
        {
            ViewBag.list = "/Areas/CssJquery/Img/1.jpg";
            //ViewData["list10"] = ;
            List<string> list3 = new List<string>(){
                "/Areas/CssJquery/Img/10.jpg"
            };
            ViewData["list10"] =list3;

            ViewBag.list2 = new List<string>{
            "/Areas/CssJquery/Img/2.jpg",
            "/Areas/CssJquery/Img/3.jpg",
            "/Areas/CssJquery/Img/4.jpg",
            "/Areas/CssJquery/Img/5.jpg",
            "/Areas/CssJquery/Img/6.jpg",
            "/Areas/CssJquery/Img/7.jpg",
            "/Areas/CssJquery/Img/8.jpg",
            "/Areas/CssJquery/Img/9.jpg"
            
            };
            return View();
        }
        public ActionResult AccordionDemo()
        {
            return View();
        }

        public ActionResult JDIndex()
        {
            return View();
        }
        public ActionResult JDFTGQ()
        {
            return View();
        }
        public ActionResult StairDemo()
        {
            return View();
        }
        public ActionResult TableDemo()
        {
            return View();
        }

        public ActionResult JqueryValidate()
        {
            return View();
        }
    }
}