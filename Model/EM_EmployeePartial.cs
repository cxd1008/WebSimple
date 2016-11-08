using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class EM_Employee
    {
        private WebMvcEntities db = new WebMvcEntities();
        public string SYSEmTypeDDName
        {
            get
            {
                return db.SYS_DD.Where(s => s.DDType == "EmType" && s.DDCode == this.EmType).FirstOrDefault().DDName;
            }
        }
        //public virtual JF_Tasks JF_Tasks
        //{
        //    get;

        //    set;
        //}

        //public virtual ICollection<JF_Tasks> JF_Tasks { get; set; }
    }
}
