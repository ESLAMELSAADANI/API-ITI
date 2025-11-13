namespace Day01.Repository
{
    public interface IEntityRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync<S>(S id);
        Task AddAsync(T entity);
        void Edit(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
