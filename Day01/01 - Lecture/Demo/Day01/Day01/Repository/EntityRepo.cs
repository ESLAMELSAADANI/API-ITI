
using Day01.Models;
using Microsoft.EntityFrameworkCore;

namespace Day01.Repository
{
    public class EntityRepo<T> : IEntityRepo<T> where T : class
    {
        protected ITIDbContext dbContext;

        public EntityRepo(ITIDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public virtual T GetById<S>(S id)
        {
            return dbContext.Set<T>().Find(id);
        }

        //public int SaveChanges()
        //{
        //    return dbContext.SaveChanges();
        //}
    }
}
