namespace Day01.Repository
{
    public interface IEntityRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById<S>(S id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        int SaveChanges();
    }
}
