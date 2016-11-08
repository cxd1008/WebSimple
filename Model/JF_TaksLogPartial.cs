using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class JF_TasksLog
    {
        private WebMvcEntities db = new WebMvcEntities();

        public string EMCreatedByRealName
        {
            get
            {
                return db.EM_Employee.Find(this.CreatedBy).EMRealName;
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
