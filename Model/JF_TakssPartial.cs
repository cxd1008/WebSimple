using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class JF_Tasks
    {
        private WebMvcEntities db = new WebMvcEntities();
        public string EMExecutorRealName
        {
            get
            {
                string Executor = "";
                if (this.Executor != null)
                {
                    var vExecutor = db.EM_Employee.Find(this.Executor);
                    if (vExecutor != null)
                    {
                        Executor = vExecutor.EMRealName;
                    }
                }
                return Executor;
            }
        }
        public string EMTestEmployeeRealName
        {
            get
            {
                string TestEmployee = "";
                if (this.TestEmployee != null)
                {
                    var vTestEmployee = db.EM_Employee.Find(this.TestEmployee);
                    if (vTestEmployee != null)
                    {
                        TestEmployee = vTestEmployee.EMRealName;
                    }
                }
                return TestEmployee;
            }
        }

        public string EMDemandEmployeeRealName
        {
            get
            {
                string DemandEmployee = "";
                if (this.DemandEmployee != null)
                {
                    var vDemandEmployee = db.EM_Employee.Find(this.DemandEmployee);
                    if (vDemandEmployee != null)
                    {
                        DemandEmployee = vDemandEmployee.EMRealName;
                    }
                }
                return DemandEmployee;
            }
        }

        public string EMCreatedByRealName
        {
            get
            {
                string CreatedBy = "";
                if (this.CreatedBy != null)
                {
                    var vCreatedBy = db.EM_Employee.Find(this.CreatedBy);
                    if (vCreatedBy != null)
                    {
                        CreatedBy = vCreatedBy.EMRealName;
                    }
                }
                return CreatedBy;
            }
        }
        public string SYSFinishStatusDDName
        {
            get
            {
                return db.SYS_DD.Where(s => s.DDType == "FinishStatus" && s.DDCode == this.FinishStatus).FirstOrDefault().DDName;
            }
        }


    }
}
