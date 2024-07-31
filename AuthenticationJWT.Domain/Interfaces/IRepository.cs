using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationJWT.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T? Get(int id);
        Task<T?> GetAsync(int id);
        IQueryable<T?> Find(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void InsertRange(List<T> entities);
        Task InsertRangeAsync(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
    }
}
