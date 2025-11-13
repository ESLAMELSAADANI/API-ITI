
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

        public async Task AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync<S>(S id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
