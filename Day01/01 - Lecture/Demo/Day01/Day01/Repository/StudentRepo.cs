using Day01.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Day01.Repository
{
    public interface IStudentRepoExtra
    {
        public Task<IEnumerable<Student>> GetByAddressAsync(string address);
    }
    public class StudentRepo : EntityRepo<Student>, IStudentRepoExtra
    {

        public StudentRepo(ITIDbContext _dbContext) : base(_dbContext)
        {
        }

        public override Task<Student> GetByIdAsync<S>(S id)
        {
            return dbContext.Students.AsNoTracking().SingleOrDefaultAsync(s => s.StId == id as int?);
        }

        public async Task<IEnumerable<Student>> GetByAddressAsync(string address)
        {
            return await dbContext.Students.Where(s => s.StAddress == address).ToListAsync();
        }
    }
}
