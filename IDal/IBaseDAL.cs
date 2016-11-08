using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
   public interface IBaseDAL<T> where T:class,new()
    {
        T AddEntity(T entity);
        bool DeleteEntity(T entity);

        bool UpdateEntity(T entity);

        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        T LoadEntity(Expression<Func<T, bool>> wherelambda);

        IQueryable<T> LoadEntities<s>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc);

        IQueryable<T> LoadTopEntity<s>(int top, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc);

        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc);
    }
}
