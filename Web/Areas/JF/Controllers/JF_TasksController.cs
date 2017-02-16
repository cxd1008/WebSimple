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
using System.Data.Entity.Infrastructure;
using Web.Controllers;
using EFDAL;
namespace Web.Areas.JF.Controllers
{
    public class JF_TasksController : Controller
    {
        //private WebMvcEntities db = new WebMvcEntities();

        //DbContext mydbContext = (WebMvcEntities)DbContextFactory.GetCurrentDbContext();
        /// <summary>
        /// 同一进程线程,可以在多个类程序一起提交
        /// </summary>
        WebMvcEntities db = (WebMvcEntities)DbContextFactory.GetCurrentDbContext();

        public int funp(int i, string a)
        {
            return 1;
        }

        // GET: /Tasks/JF_Tasks/ 
        public ActionResult Index(Guid? EMRealName, string FinishStatus, string TaskNeeds, string sTime, string eTime, string h1, int id = 1)
        {

            //Func<int, string, int> func = (a, x) => funp(a,x);
            //int i = 
            //func.BeginInvoke(1, "a",null,null);

            var TasksPL = db.JF_Tasks.AsQueryable();
            //var TasksPL2 = db.JF_Tasks.AsEnumerable();
            //var TasksPL = from ta in db.JF_Tasks select ta;
            //var TasksPL4 = db.JF_Tasks.ToList();
            if (h1 != "1")
            {
                sTime = DateTime.Now.Year + "-" + DateTime.Now.Month + "-1";
                eTime = DateTime.Now.ToShortDateString();
            }
            if (!string.IsNullOrEmpty(sTime) && !string.IsNullOrEmpty(eTime))
            {
                DateTime dsTime = Convert.ToDateTime(sTime);
                DateTime deTime = Convert.ToDateTime(eTime).AddDays(1);
                TasksPL = TasksPL.Where(s => s.CreatedOn >= dsTime && s.CreatedOn <= deTime);
            }
            if (EMRealName != null)
            {
                TasksPL = TasksPL.Where(s => s.Executor == EMRealName || s.TestEmployee == EMRealName || s.DemandEmployee == EMRealName);
            }
            if (!string.IsNullOrEmpty(FinishStatus))
            {
                TasksPL = TasksPL.Where(s => s.FinishStatus == FinishStatus);
            }
            if (!string.IsNullOrEmpty(TaskNeeds))
            {
                TasksPL = TasksPL.Where(s => s.TaskNeeds.Contains(TaskNeeds));
            }
            ViewBag.FinishStatus = new SelectList(db.SYS_DD.Where(s => s.DDType == "FinishStatus").OrderBy(s => s.DDCode), "DDCode", "DDName", FinishStatus);
            ViewBag.EMRealName = new SelectList(db.EM_Employee.Where(s => s.IsDisabled != false).OrderBy(s => s.EMRealName), "Emid", "EMRealName", EMRealName);
            return View(TasksPL.OrderBy(s => s.CreatedOn).ToPagedList(id, 50));
        }

        // GET: /Tasks/JF_Tasks/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JF_Tasks jf_tasks = await db.JF_Tasks.FindAsync(id);
            if (jf_tasks == null)
            {
                return HttpNotFound();
            }
            return View(jf_tasks);
        }
        [IsLogin]
        // GET: /Tasks/JF_Tasks/Create
        public ActionResult Create()
        {
            ViewBag.Executor = new SelectList(db.EM_Employee.Where(s => s.EmType == "01" && s.IsDisabled != false).OrderBy(s => s.EMRealName), "Emid", "EMRealName");
            ViewBag.TestEmployee = new SelectList(db.EM_Employee.Where(s => s.EmType == "02" && s.IsDisabled != false).OrderBy(s => s.EMRealName), "Emid", "EMRealName");
            ViewBag.DemandEmployee = new SelectList(db.EM_Employee.Where(s => s.EmType == "03" && s.IsDisabled != false).OrderBy(s => s.EMRealName), "Emid", "EMRealName");
            ViewBag.FinishStatus = new SelectList(db.SYS_DD.Where(s => s.DDType == "FinishStatus").OrderBy(s => s.DDCode), "DDCode", "DDName");

            return View();
        }
        [IsLogin]
        // POST: /Tasks/JF_Tasks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TasksID,TaskNeeds,ExecutorScore,TechnicalFactor,TimeFactor,DemandDetailFactor,TestEvaluteFactor,NeedsEvaluteFactor,ExecutorGetScore,Executor,TestFactor,OnlinePublishFactor,TestScore,TestEmployee,DemandFactor,DemandScore,DemandEmployee,FinishStatus")] JF_Tasks jf_tasks)
        {
            if (ModelState.IsValid)
            {
                jf_tasks.TasksID = Guid.NewGuid();
                jf_tasks.ExecutorGetScore = jf_tasks.ExecutorScore * jf_tasks.TechnicalFactor * jf_tasks.TimeFactor * jf_tasks.DemandDetailFactor * jf_tasks.TestEvaluteFactor * jf_tasks.NeedsEvaluteFactor;
                jf_tasks.TestScore = jf_tasks.TestFactor * jf_tasks.ExecutorGetScore * jf_tasks.OnlinePublishFactor;
                jf_tasks.DemandScore = jf_tasks.DemandFactor * jf_tasks.ExecutorGetScore;
                jf_tasks.CreatedOn = DateTime.Now;
                jf_tasks.CreatedBy = Common.SessionClass.GetSession.EmID;
                db.JF_Tasks.Add(jf_tasks);
                await db.SaveChangesAsync();
                SetJF_TasksLog(jf_tasks.TasksID, jf_tasks.FinishStatus);
                return Content("ok");
            }

            return View(jf_tasks);
        }
        /// <summary>
        /// 日志表
        /// </summary>
        /// <param name="TasksID"></param>
        /// <param name="FinishStatus"></param>
        private void SetJF_TasksLog(Guid TasksID, string FinishStatus)
        {
            JF_TasksLog myJF_TasksLog = new JF_TasksLog();
            myJF_TasksLog.TasksLogID = Guid.NewGuid();
            myJF_TasksLog.TasksID = TasksID;
            myJF_TasksLog.FinishStatus = FinishStatus;
            myJF_TasksLog.CreatedBy = Common.SessionClass.GetSession.EmID;
            myJF_TasksLog.CreatedOn = DateTime.Now;
            db.JF_TasksLog.Add(myJF_TasksLog);
            db.SaveChanges();
        }
        [IsLogin]

        // GET: /Tasks/JF_Tasks/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JF_Tasks jf_tasks = await db.JF_Tasks.FindAsync(id);
            ViewBag.Executor = new SelectList(db.EM_Employee.Where(s => s.EmType == "01").OrderBy(s => s.EMRealName), "Emid", "EMRealName", jf_tasks.Executor);
            ViewBag.TestEmployee = new SelectList(db.EM_Employee.Where(s => s.EmType == "02").OrderBy(s => s.EMRealName), "Emid", "EMRealName", jf_tasks.TestEmployee);
            ViewBag.DemandEmployee = new SelectList(db.EM_Employee.Where(s => s.EmType == "03").OrderBy(s => s.EMRealName), "Emid", "EMRealName", jf_tasks.DemandEmployee);
            ViewBag.FinishStatus = new SelectList(db.SYS_DD.Where(s => s.DDType == "FinishStatus").OrderBy(s => s.DDCode), "DDCode", "DDName", jf_tasks.FinishStatus);
            if (jf_tasks == null)
            {
                return HttpNotFound();
            }
            return View(jf_tasks);
        }

        // POST: /Tasks/JF_Tasks/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [IsLogin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TasksID,TaskNeeds,ExecutorScore,TechnicalFactor,TimeFactor,DemandDetailFactor,TestEvaluteFactor,NeedsEvaluteFactor,ExecutorGetScore,Executor,TestFactor,OnlinePublishFactor,TestScore,TestEmployee,DemandFactor,DemandScore,DemandEmployee,FinishStatus")] JF_Tasks jf_tasks)
        {
            if (ModelState.IsValid)
            {
                jf_tasks.ExecutorGetScore = jf_tasks.ExecutorScore * jf_tasks.TechnicalFactor * jf_tasks.TimeFactor * jf_tasks.DemandDetailFactor * jf_tasks.TestEvaluteFactor * jf_tasks.NeedsEvaluteFactor;
                jf_tasks.TestScore = jf_tasks.TestFactor * jf_tasks.ExecutorGetScore * jf_tasks.OnlinePublishFactor;
                jf_tasks.DemandScore = jf_tasks.DemandFactor * jf_tasks.ExecutorGetScore;

                db.Entry(jf_tasks).State = EntityState.Modified;
                //1.将实体对象a 加入到EF 对象容器中,并 b获取 伪包装类 对象
                DbEntityEntry<JF_Tasks> entry = db.Entry<JF_Tasks>(jf_tasks);
                //2.将包装类对象 的状态设置为 Unchanged
                //entry.State = EntityState.Modified;
                //3.设置 被改变的 属性
                entry.Property(a => a.CreatedOn).IsModified = false;
                entry.Property(a => a.CreatedBy).IsModified = false;
                //db.Entry(jf_tasks).State = EntityState.Modified;
                await db.SaveChangesAsync();
                SetJF_TasksLog(jf_tasks.TasksID, jf_tasks.FinishStatus);
                return Content("ok");
            }
            return View(jf_tasks);
        }

        // GET: /Tasks/JF_Tasks/Delete/5
        [IsLogin]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JF_Tasks jf_tasks = await db.JF_Tasks.FindAsync(id);
            if (jf_tasks == null)
            {
                return HttpNotFound();
            }
            return View(jf_tasks);
        }

        // POST: /Tasks/JF_Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [IsLogin]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            JF_Tasks jf_tasks = await db.JF_Tasks.FindAsync(id);
            db.JF_Tasks.Remove(jf_tasks);
            await db.SaveChangesAsync();
            return Content("ok");
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
