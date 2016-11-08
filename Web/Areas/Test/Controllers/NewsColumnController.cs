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

namespace Web.Areas.Test.Controllers
{
    public class NewsColumnController : Controller
    {
        private WebMvcEntities db = new WebMvcEntities();

        // GET: /Test/NewsColumn/
        public async Task<ActionResult> Index()
        {
            return View(await db.NewsColumn.ToListAsync());
        }

        // GET: /Test/NewsColumn/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsColumn newscolumn = await db.NewsColumn.FindAsync(id);
            if (newscolumn == null)
            {
                return HttpNotFound();
            }
            return View(newscolumn);
        }

        // GET: /Test/NewsColumn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Test/NewsColumn/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ColumnID,ColumnPID,ColumnName,CreateTime,CreateBy,IsDeleted")] NewsColumn newscolumn)
        {
            if (ModelState.IsValid)
            {
                newscolumn.ColumnID = Guid.NewGuid();
                db.NewsColumn.Add(newscolumn);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(newscolumn);
        }

        // GET: /Test/NewsColumn/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsColumn newscolumn = await db.NewsColumn.FindAsync(id);
            if (newscolumn == null)
            {
                return HttpNotFound();
            }
            return View(newscolumn);
        }

        // POST: /Test/NewsColumn/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ColumnID,ColumnPID,ColumnName,CreateTime,CreateBy,IsDeleted")] NewsColumn newscolumn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newscolumn).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newscolumn);
        }

        // GET: /Test/NewsColumn/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsColumn newscolumn = await db.NewsColumn.FindAsync(id);
            if (newscolumn == null)
            {
                return HttpNotFound();
            }
            return View(newscolumn);
        }

        // POST: /Test/NewsColumn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            NewsColumn newscolumn = await db.NewsColumn.FindAsync(id);
            db.NewsColumn.Remove(newscolumn);
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
