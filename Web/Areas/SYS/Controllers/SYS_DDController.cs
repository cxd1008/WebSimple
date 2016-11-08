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

namespace Web.Areas.SYS.Controllers
{
    public class SYS_DDController : Controller
    {
        private WebMvcEntities db = new WebMvcEntities();

        // GET: /SYS/SYS_DD/
        public async Task<ActionResult> Index()
        {
            return View(await db.SYS_DD.OrderBy(s => new {s.DDType ,s.DDCode}).ToListAsync());
        }

        // GET: /SYS/SYS_DD/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SYS_DD sys_dd = await db.SYS_DD.FindAsync(id);
            if (sys_dd == null)
            {
                return HttpNotFound();
            }
            return View(sys_dd);
        }

        // GET: /SYS/SYS_DD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SYS/SYS_DD/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="DDid,DDCode,DDName,DDType,DDSort")] SYS_DD sys_dd)
        {
            if (ModelState.IsValid)
            {
                sys_dd.DDid = Guid.NewGuid();
                db.SYS_DD.Add(sys_dd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sys_dd);
        }

        // GET: /SYS/SYS_DD/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SYS_DD sys_dd = await db.SYS_DD.FindAsync(id);
            if (sys_dd == null)
            {
                return HttpNotFound();
            }
            return View(sys_dd);
        }

        // POST: /SYS/SYS_DD/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="DDid,DDCode,DDName,DDType,DDSort")] SYS_DD sys_dd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_dd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sys_dd);
        }

        // GET: /SYS/SYS_DD/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SYS_DD sys_dd = await db.SYS_DD.FindAsync(id);
            if (sys_dd == null)
            {
                return HttpNotFound();
            }
            return View(sys_dd);
        }

        // POST: /SYS/SYS_DD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SYS_DD sys_dd = await db.SYS_DD.FindAsync(id);
            db.SYS_DD.Remove(sys_dd);
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
