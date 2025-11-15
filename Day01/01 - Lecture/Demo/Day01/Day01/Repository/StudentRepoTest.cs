using AutoMapper;
using Day01.Models;

namespace Day01.Repository
{
    public class StudentRepoTest : IEntityRepo<Student>
    {
        IMapper mapper;
        static List<Student> stds = new List<Student>
{
    new Student
    {
        StId = 1,
        StFname = "Eslam",
        StLname = "Ashraf",
        StAge = 26,
        StAddress = "Cairo",
        DeptId = 10,
        StSuper = 1
    },
    new Student
    {
        StId = 2,
        StFname = "Mohamed",
        StLname = "Ali",
        StAge = 23,
        StAddress = "Alex",
        DeptId = 20,
        StSuper = 1
    },
    new Student
    {
        StId = 3,
        StFname = "Sara",
        StLname = "Youssef",
        StAge = 22,
        StAddress = "Mansoura",
        DeptId = 10,
        StSuper = 2
    }
};

        public StudentRepoTest(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public void Add(Student entity)
        {
            stds.Add(entity);
        }

        public void Delete(Student entity)
        {
            stds.Remove(entity);
        }

        public void Edit(Student entity)
        {
            var std = stds.SingleOrDefault(s => s.StId == entity.StId);
            if (std != null)
            {
                std.StFname = entity.StFname;
                std.StLname = entity.StLname;
                std.StAge = entity.StAge;
                std.StAddress = entity.StAddress;
                std.DeptId = entity.DeptId;
                std.StSuper = entity.StSuper;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return stds.ToList();
        }

        public Student GetById<S>(S id)
        {
            return stds.SingleOrDefault(s => s.StId == id as int?);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
