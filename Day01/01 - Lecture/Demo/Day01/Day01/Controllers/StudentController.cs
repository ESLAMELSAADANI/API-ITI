using AutoMapper;
using Day01.DTOs.StudentDTOs;
using Day01.Models;
using Day01.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Day01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IMapper mapper;
        IEntityRepo<Student> studentRepo;
        IEntityRepo<Department> departmentRepo;
        //EntityRepo<Student> studentRepo;
        //EntityRepo<Department> departmentRepo;
        IStudentRepoExtra studentRepoExtra;

        public StudentController(IMapper _mapper, /*EntityRepo<Student> _studentRepo*/ /*,*/  IStudentRepoExtra _studentRepoExtra, IEntityRepo<Department> _departmentRepo, IEntityRepo<Student> _studentRepo)
        {
            mapper = _mapper;
            studentRepo = _studentRepo;
            studentRepoExtra = _studentRepoExtra;
            departmentRepo = _departmentRepo;
        }

        [HttpGet]
        public IActionResult GetAll(string? search, int pageNumber = 1, int pageSize = 5)
        {
            var query = studentRepo.GetAll();

            // 🔍 Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(s =>
                    s.StFname.Contains(search) ||
                    s.StAddress.Contains(search));
            }

            // 🧮 Count total
            var totalRecords = query.Count();

            // ⚙️ If pageSize = 0 (or negative), return all
            if (pageSize <= 0)
            {
                var allStudents = query;
                var allDTOs = mapper.Map<List<ReadStudentDTO>>(allStudents);
                return Ok(new
                {
                    totalRecords,
                    data = allDTOs
                });
            }

            // 🧭 Pagination
            var students = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var stdDTOs = mapper.Map<List<ReadStudentDTO>>(students);
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return Ok(new
            {
                currentPage = pageNumber,
                pageSize,
                totalRecords,
                totalPages,
                data = stdDTOs
            });
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //	var stds = dbContext.Students.ToList();
        //	if (stds == null || stds.Count == 0)
        //		return NotFound();
        //	//List<ReadStudentDTO> stdsDTO = new List<ReadStudentDTO>();
        //	//foreach (var std in stds)
        //	//{
        //	//    stdsDTO.Add(new ReadStudentDTO()
        //	//    {
        //	//        Id = std.StId,
        //	//        Name = std.StFname + " " + std.StLname,
        //	//        Address = std.StAddress,
        //	//        Age = std.StAge ?? 0,
        //	//        DeptId = std.DeptId ?? 0,
        //	//        DeptName = std.Dept?.DeptName ?? "No Department"
        //	//    });
        //	//}

        //	//Auto Mapper
        //	List<ReadStudentDTO> stdsDTO = mapper.Map<List<ReadStudentDTO>>(stds);
        //	return Ok(stdsDTO);
        //}

        [HttpGet("{id:int}")]
        public IActionResult GetById(int? id)
        {
            if (id == null)
                return BadRequest();
            var std = studentRepo.GetById<int>(id.Value);
            if (std == null)
                return NotFound();
            //DTOs
            //var stdDTO = new ReadStudentDTO()
            //{
            //    Id = std.StId,
            //    Name = std.StFname + " " + std.StLname,
            //    Age = std.StAge,
            //    Address = std.StAddress,
            //    DeptId = std.DeptId,
            //    DeptName = std.Dept.DeptName
            //};

            //Auto Mapper
            ReadStudentDTO stdDTO = mapper.Map<ReadStudentDTO>(std);
            return Ok(stdDTO);
        }

        [HttpGet("/api/student/address/{address}")]
        //[HttpGet("{name:alpha}")]
        public IActionResult GetByAddress(string address)
        {
            if (address == null)
                return BadRequest();
            var stds = studentRepoExtra.GetByAddress(address);
            if (stds == null)
                return NotFound();
            //Auto Mapper
            List<ReadStudentDTO> stdsDTO = mapper.Map<List<ReadStudentDTO>>(stds);
            return Ok(stdsDTO);
        }

        [HttpPost]
        public  IActionResult Add(AddStudentDTO stdDTO)
        {
            if (stdDTO == null)
                return BadRequest();
            if (ModelState.IsValid)
            {
                //Student std = new Student()
                //{
                //    StId = stdDTO.Id,
                //    StFname = stdDTO.Name,
                //    StAge = stdDTO.Age,
                //    StAddress = stdDTO.Address,
                //    DeptId = stdDTO.DeptId,
                //};
                //std.Dept = dbContext.Departments.SingleOrDefault(d => d.DeptId == std.DeptId);

                //Auto Mapper
                Student std = mapper.Map<Student>(stdDTO);

                studentRepo.Add(std);
                studentRepo.SaveChanges();
                //var rStdDTO = new ReadStudentDTO()
                //{
                //    Id = stdDTO.Id,
                //    Name = stdDTO.Name,
                //    Age = stdDTO.Age,
                //    Address = stdDTO.Address,
                //    DeptId = stdDTO.DeptId ?? 0,
                //    DeptName = std.Dept?.DeptName ?? "No Dept"
                //};

                //Auto Mapper
                ReadStudentDTO rStdDTO = mapper.Map<ReadStudentDTO>(std);

                return RedirectToAction("GetById", new { id = std.StId });
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, AddStudentDTO std)
        { 
            if (std == null)
                return BadRequest();
            if (id != std.Id)
                return BadRequest();
            //var student = dbContext.Students.AsNoTracking().SingleOrDefault(s => s.StId == id);
            var student = studentRepo.GetById<int>(id);
            if (student == null)
                return NotFound();
            Student model = mapper.Map<Student>(std);
            model.Dept = departmentRepo.GetById<int>(std.DeptId.Value);
            if (ModelState.IsValid)
            {
                studentRepo.Edit(model);
                studentRepo.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var std = studentRepo.GetById<int>(id.Value);
            if (std == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                var stdDTO = mapper.Map<ReadStudentDTO>(std);
                studentRepo.Delete(std);
                studentRepo.SaveChanges();
                return Ok(stdDTO);
            }
            return BadRequest();
        }
    }
}
