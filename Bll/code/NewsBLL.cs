using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDAL;
//using IDAL;
using Model;

namespace BLL
{
    public class NewsBLL
    {
        //public List<News> NewsList()
        //{
        //    INewsDAL iNewsDAL = new NewsDAL();
        //    return iNewsDAL.NewsListDAL();
        //}
        WebMvcEntities db = (WebMvcEntities)DbContextFactory.GetCurrentDbContext();
        public IQueryable<News> NewsList2()
        {
            var NewsList2 = db.News;
            return NewsList2;
        }

    }
}
