using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreASP.DataAccess.Repository
{
    public interface IRepository <T>where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Remove(T entity);  
        void RemoveRange(IEnumerable<T> entities);
    }
}
