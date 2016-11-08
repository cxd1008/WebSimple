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

namespace Web.Areas.JF.Controllers
{
    public class JF_TasksStatsController : Controller
    {
        private WebMvcEntities db = new WebMvcEntities();

        // GET: /Tasks/JF_Tasks/
        public ActionResult Index(Guid? EMRealName, string h1, string sTime, string eTime, string sEmType, int id = 1)
        {

            if (h1 != "1")
            {
                sTime = DateTime.Now.Year + "-" + DateTime.Now.Month + "-1";
                eTime = DateTime.Now.AddDays(1).ToShortDateString();
            }

            List<JF_TasksStats> listJF_TasksStats = new List<JF_TasksStats>();
            List<EM_Employee> listEM = new List<EM_Employee>();

            ViewBag.EMRealName = new SelectList(db.EM_Employee.OrderBy(s => s.EMRealName), "Emid", "EMRealName", EMRealName);
            if (string.IsNullOrEmpty(sTime) && string.IsNullOrEmpty(eTime))
            {
                return View(listJF_TasksStats.ToPagedList(1,20));
            }

           
            if (EMRealName != null)
            {
                listEM = db.EM_Employee.Where(s => s.EmID == EMRealName).ToList();
            }
            else
            {
                listEM = db.EM_Employee.ToList();
            }

            foreach (EM_Employee itemEM in listEM)
            {
                listJF_TasksStats.Add(myJF_TasksStats(itemEM, Convert.ToDateTime(sTime), Convert.ToDateTime(eTime).AddDays(1)));

            }

            return View(listJF_TasksStats.OrderByDescending(s => s.GetScore).ToPagedList(id, 20));
        }

        private JF_TasksStats myJF_TasksStats(EM_Employee gEM, DateTime sTime, DateTime eTime)
        {
            JF_TasksStats myJF_TasksStats = new JF_TasksStats();
            myJF_TasksStats.EMRealName = gEM.EMRealName;
            myJF_TasksStats.EmType = db.SYS_DD.Where(s => s.DDCode == gEM.EmType && s.DDType == "EmType").FirstOrDefault().DDName;
            switch (gEM.EmType)
            {
                case "01":
                    myJF_TasksStats.BaseScore = db.JF_Tasks.Where(s => s.Executor == gEM.EmID && s.CreatedOn >= sTime && s.CreatedOn <= eTime).Sum(s => s.ExecutorGetScore);
                    break;
                case "02":
                    myJF_TasksStats.BaseScore = db.JF_Tasks.Where(s => s.TestEmployee == gEM.EmID && s.CreatedOn >= sTime && s.CreatedOn <= eTime).Sum(s => s.TestScore);
                    break;
                default:
                    myJF_TasksStats.BaseScore = db.JF_Tasks.Where(s => s.DemandEmployee == gEM.EmID && s.CreatedOn >= sTime && s.CreatedOn <= eTime).Sum(s => s.DemandScore);
                    break;
            }

            double? ExecutorGetScore = db.JF_Tasks.Where(s => (s.FinishStatus == "04" || s.FinishStatus == "05") && s.Executor == gEM.EmID && s.CreatedOn >= sTime && s.CreatedOn <= eTime).Sum(s => s.ExecutorGetScore);
            double? TestScore = db.JF_Tasks.Where(s => s.FinishStatus == "05" && s.TestEmployee == gEM.EmID && s.CreatedOn >= sTime && s.CreatedOn <= eTime).Sum(s => s.TestScore);
            double? DemandScore = db.JF_Tasks.Where(s =>(s.FinishStatus == "04" || s.FinishStatus == "05") && s.DemandEmployee == gEM.EmID && s.CreatedOn >= sTime && s.CreatedOn <= eTime).Sum(s => s.DemandScore);
            myJF_TasksStats.GetScore = (ExecutorGetScore == null ? 0 : ExecutorGetScore) + (TestScore == null ? 0 : TestScore) + (DemandScore == null ? 0 : DemandScore);
            myJF_TasksStats.Money = myJF_TasksStats.GetScore * 5;
            return myJF_TasksStats;
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
