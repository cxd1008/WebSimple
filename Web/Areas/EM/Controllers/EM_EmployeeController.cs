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
using Web.Controllers;
namespace Web.Areas.EM.Controllers
{
    
    public class EM_EmployeeController : Controller
    {
        private WebMvcEntities db = new WebMvcEntities();

        // GET: /EM/EM_Employee/
        public async Task<ActionResult> Index()
        {
            return View(await db.EM_Employee.OrderBy(s => s.EMRealName).ToListAsync());
        }

        // GET: /EM/EM_Employee/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EM_Employee em_employee = await db.EM_Employee.FindAsync(id);
            if (em_employee == null)
            {
                return HttpNotFound();
            }
            return View(em_employee);
        }

        // GET: /EM/EM_Employee/Create
    
        public ActionResult Create()
        {
            ViewBag.EmType = new SelectList(db.SYS_DD.Where(s => s.DDType == "EmType").OrderBy(s=>s.DDCode), "DDCode", "DDName");
            return View();
        }

        // POST: /EM/EM_Employee/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="EmID,EMUserName,EMPassWord,EMRealName,EmType,Mobile,IsDisabled,CreatedOn,CreatedBy")] EM_Employee em_employee)
        {
            if (ModelState.IsValid)
            {
                em_employee.EmID = Guid.NewGuid();
                db.EM_Employee.Add(em_employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(em_employee);
        }
        [IsLogin]
        // GET: /EM/EM_Employee/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EM_Employee em_employee = await db.EM_Employee.FindAsync(id);
            ViewBag.EmType = new SelectList(db.SYS_DD.Where(s => s.DDType == "EmType"), "DDCode", "DDName",em_employee.EmType);
            if (em_employee == null)
            {
                return HttpNotFound();
            }
            return View(em_employee);
        }

        // POST: /EM/EM_Employee/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [IsLogin]
        public async Task<ActionResult> Edit([Bind(Include="EmID,EMUserName,EMPassWord,EMRealName,EmType,Mobile,IsDisabled,CreatedOn,CreatedBy")] EM_Employee em_employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(em_employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(em_employee);
        }

        // GET: /EM/EM_Employee/Delete/5
        [IsLogin]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EM_Employee em_employee = await db.EM_Employee.FindAsync(id);
            if (em_employee == null)
            {
                return HttpNotFound();
            }
            return View(em_employee);
        }

        // POST: /EM/EM_Employee/Delete/5
        [IsLogin]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            EM_Employee em_employee = await db.EM_Employee.FindAsync(id);
            db.EM_Employee.Remove(em_employee);
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
