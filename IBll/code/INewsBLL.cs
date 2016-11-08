using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IProjectBLL
    {
        /// <summary>
        /// 接口方法
        /// </summary>
        /// <returns></returns>
        List<News> ProjectList();
        /// <summary>
        /// 直接使用方法
        /// </summary>
        /// <returns></returns>
        IQueryable<News> ProjectList2();
    }
}
