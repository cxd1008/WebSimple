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
using Webdiyer.WebControls.Mvc;

namespace Web.Areas.Jiaoyu361.Controllers
{
    public class IndexController : Controller
    {
        private WebMvcEntities db = new WebMvcEntities();

        // GET: /Jiaoyu361/Index/
        //public async Task<ActionResult> Index()
        //{
        //    var news = db.News.Include(n => n.NewsColumn);
        //    return View(await news.ToListAsync());
        //}
        public async Task<ActionResult> Index()
        {
            var news = db.News.OrderByDescending(s=>s.CreateTime).Include(n => n.NewsColumn).ToPagedList(1,5);
            return View(news);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
