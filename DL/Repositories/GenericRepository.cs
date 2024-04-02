using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Base
    {
        private readonly ApplicationDBContext context;
        private DbSet<T> entities;
        public GenericRepository(ApplicationDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public T Get(long id)
        {
            return entities.FirstOrDefault(_ => _.Id == id);
        }
        public int Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }

        public void BulkInsert(List<T> entities)
        {
            if (entities == null || entities.Count() == 0)
            {
                throw new ArgumentNullException("entity");
            }
            entities.AddRange(entities);
            context.SaveChanges();
        }
        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();

            return entity.Id;
        }
        public int Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            //entities.Remove(entity);
            context.SaveChanges();

            return entity.Id;
        }

        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
