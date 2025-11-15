using Day01.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Day01.Repository
{
    //public interface IStudentRepoExtra
    //{
    //    public IEnumerable<Student> GetByAddress(string address);
    //}
    public class StudentRepo : EntityRepo<Student>
    {

        public StudentRepo(ITIDbContext _dbContext) : base(_dbContext)
        {
        }

        public override Student GetById<S>(S id)
        {
            return dbContext.Students.AsNoTracking().SingleOrDefault(s => s.StId == id as int?);
        }

        public IEnumerable<Student> GetByAddress(string address)
        {
            return dbContext.Students.Where(s => s.StAddress == address).ToList();
        }
    }
}
