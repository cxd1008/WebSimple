using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 统计类
    /// </summary>
    public class JF_TasksStats
    {
        public string EMRealName { get; set; }
        public string EmType { get; set; }
        public Nullable<double> BaseScore { get; set; }
        public Nullable<double> GetScore { get; set; }
        public Nullable<double> Money { get; set; }

    }
}
