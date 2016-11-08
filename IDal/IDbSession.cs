using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
   public partial interface IDbSession
    {
        int ExecuteSql(string sql, params SqlParameter[] pars);

        IQueryable<T> ExecuteQuery<T>(string sql, params System.Data.SqlClient.SqlParameter[] pars);

        int SaveChanges();
    }
}
