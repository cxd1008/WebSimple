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
using Webdiyer.WebControls.Mvc;//翻页控件包

namespace Web.Areas.Test.Controllers
{
    public class NewsController : Controller
    {
        private WebMvcEntities db = new WebMvcEntities();

        public class NewsModel
        {
            public IPagedList<News> MyNews1 { get; set; }
            public IPagedList<News> MyNews2 { get; set; }
        }

        // GET: /Test/News/
        public async Task<ActionResult> Index()
        {
            PagedList<News> News = db.News.Include(e => e.NewsColumn).OrderByDescending(u => u.CreateTime).ToPagedList(1, 5);
            PagedList<News> News2 = null;
            //for (int i = 0; i < News.Count; i++)
            //{
            //    News2[i].NewsAuthor = News[i].NewsAuthor;
            //    News2[i].NewsColumn = News[i].NewsColumn;
            //    News2[i].NewsTitle = News[i].NewsTitle;
            //    News2[i].OrderByNum = News[i].OrderByNum;
            //    News2[i].NewsContent = News[i].NewsContent;
                
            //}
            //PagedList<News> PNews = db.News.OrderByDescending(u => u.CreateTime).ToPagedList(1, 5);            
            return View(News);
        }

        // GET: /Test/News/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = await db.News.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: /Test/News/Create
        public ActionResult Create()
        {
            ViewBag.NewsColumnID = new SelectList(db.NewsColumn, "ColumnID", "ColumnName");
            return View();
        }

        // POST: /Test/News/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create([Bind(Include = "NewsID,NewsColumnID,NewsTitle,NewsContent,NewsAuthor,OrderByNum,CreateTime,CreateBy")] News news)
        {
            if (ModelState.IsValid)
            {
                news.NewsID = Guid.NewGuid();
                db.News.Add(news);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: /Test/News/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = await db.News.FindAsync(id);
            ViewBag.NewsColumnID = new SelectList(db.NewsColumn, "ColumnID", "ColumnName", news.NewsColumnID);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: /Test/News/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "NewsID,NewsColumnID,NewsTitle,NewsContent,NewsAuthor,OrderByNum,CreateTime,CreateBy")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: /Test/News/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = await db.News.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: /Test/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            News news = await db.News.FindAsync(id);
            db.News.Remove(news);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
