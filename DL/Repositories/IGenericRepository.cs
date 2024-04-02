using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public interface IGenericRepository<T> where T : Base
    {
        IQueryable<T> GetAll();
        IQueryable<T> Select(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate);
        T Get(long id);
        int Insert(T entity);
        void BulkInsert(List<T> entities);
        int Update(T entity);
        int Delete(T entity);
    }
}
