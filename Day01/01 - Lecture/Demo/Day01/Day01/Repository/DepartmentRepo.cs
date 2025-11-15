using Day01.Models;
using Microsoft.EntityFrameworkCore;

namespace Day01.Repository
{
    public class DepartmentRepo : EntityRepo<Department>
    {
        public DepartmentRepo(ITIDbContext _dbContext) : base(_dbContext)
        {
        }
        public override Department GetById<S>(S id)
        {
            return dbContext.Departments.AsNoTracking().SingleOrDefault(d => d.DeptId == id as int?);
        }
    }
}
