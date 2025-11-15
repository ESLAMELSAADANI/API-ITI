using Day01.Models;
using Day01.Repository;

namespace Day01.UnitOfWorks
{
    public class UnitOfWork
    {
        ITIDbContext dbContext;
        EntityRepo<Department> DepartmentRepo;
        StudentRepo StudentRepo;

        public UnitOfWork(ITIDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public EntityRepo<Department> departmentRepo
        {
            get
            {
                if (DepartmentRepo == null)
                    DepartmentRepo = new DepartmentRepo(dbContext);
                return DepartmentRepo;
            }
        }

        public StudentRepo studentRepo
        {
            get
            {
                if (StudentRepo == null)
                    StudentRepo = new StudentRepo(dbContext);
                return StudentRepo;
            }
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

    }
}
