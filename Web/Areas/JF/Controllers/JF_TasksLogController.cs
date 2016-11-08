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

namespace Web.Areas.JF.Controllers
{
    public class JF_TasksLogController : Controller
    {
        private WebMvcEntities db = new WebMvcEntities();

        // GET: /JF/JF_TasksLog/
        public async Task<ActionResult> Index(Guid id)
        {
            return View(await db.JF_TasksLog.Where(s=>s.TasksID==id).OrderBy(s=>s.CreatedOn).ToListAsync());
        }

        // GET: /JF/JF_TasksLog/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JF_TasksLog jf_taskslog = await db.JF_TasksLog.FindAsync(id);
            if (jf_taskslog == null)
            {
                return HttpNotFound();
            }
            return View(jf_taskslog);
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
