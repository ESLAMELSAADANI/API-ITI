using Day01.Models;

namespace Day01.Repository
{
    public class DepartmentRepo : EntityRepo<Department>
    {
        public DepartmentRepo(ITIDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
