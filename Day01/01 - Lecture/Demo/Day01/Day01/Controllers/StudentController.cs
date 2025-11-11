using AutoMapper;
using Day01.DTOs.StudentDTOs;
using Day01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day01.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		ITIDbContext dbContext;
		IMapper mapper;

		public StudentController(ITIDbContext _dbContext, IMapper _mapper)
		{
			dbContext = _dbContext;
			mapper = _mapper;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var stds = dbContext.Students.ToList();
			if (stds == null || stds.Count == 0)
				return NotFound();
			//List<ReadStudentDTO> stdsDTO = new List<ReadStudentDTO>();
			//foreach (var std in stds)
			//{
			//    stdsDTO.Add(new ReadStudentDTO()
			//    {
			//        Id = std.StId,
			//        Name = std.StFname + " " + std.StLname,
			//        Address = std.StAddress,
			//        Age = std.StAge ?? 0,
			//        DeptId = std.DeptId ?? 0,
			//        DeptName = std.Dept?.DeptName ?? "No Department"
			//    });
			//}

			//Auto Mapper
			List<ReadStudentDTO> stdsDTO = mapper.Map<List<ReadStudentDTO>>(stds);
			return Ok(stdsDTO);
		}

		[HttpGet("{id:int}")]
		public IActionResult GetById(int? id)
		{
			if (id == null)
				return BadRequest();
			var std = dbContext.Students.SingleOrDefault(s => s.StId == id);
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
			var stds = dbContext.Students.Where(s => s.StAddress == address).ToList();
			if (stds == null)
				return NotFound();
			//var stdsDTO = new List<ReadStudentDTO>();
			//foreach (var std in stds)
			//{
			//    stdsDTO.Add(new ReadStudentDTO()
			//    {
			//        Id = std.StId,
			//        Age = std.StAge ?? 0,
			//        Name = std.StFname ?? " " + " " + std.StLname ?? " ",
			//        Address = std.StAddress ?? "No Address",
			//        DeptId = std.DeptId ?? 0,
			//        DeptName = std.Dept?.DeptName ?? "No Department"
			//    });
			//}

			//Auto Mapper
			List<ReadStudentDTO> stdsDTO = mapper.Map<List<ReadStudentDTO>>(stds);
			return Ok(stdsDTO);
		}

		[HttpPost]
		public IActionResult Add(AddStudentDTO stdDTO)
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

				dbContext.Students.Add(std);
				dbContext.SaveChanges();
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

				return CreatedAtAction("GetById", new { id = std.StId }, rStdDTO);
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
			var student = dbContext.Students.AsNoTracking().SingleOrDefault(s => s.StId == id);
			if (student == null)
				return NotFound();
			//var model = new Student()
			//{
			//	StId = std.Id,
			//	StFname = std.Name,
			//	StAge = std.Age,
			//	StAddress = std.Address,
			//	DeptId = std.DeptId
			//};
			Student model = mapper.Map<Student>(std);
			model.Dept = dbContext.Departments.SingleOrDefault(d => d.DeptId == std.DeptId);
			if (ModelState.IsValid)
			{
				dbContext.Students.Update(model);
				dbContext.SaveChanges();
				return NoContent();
			}
			return BadRequest();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int? id)
		{
			if (id == null)
				return BadRequest();
			var std = dbContext.Students.SingleOrDefault(s => s.StId == id);
			if (std == null)
				return NotFound();
			if (ModelState.IsValid)
			{
				//ReadStudentDTO stdDTO = new ReadStudentDTO()
				//{
				//	Id = std.StId,
				//	Age = std.StAge ?? 0,
				//	Address = std.StAddress ?? " ",
				//	Name = std.StFname + " " + std.StLname,
				//	DeptId = std.DeptId ?? 0,
				//	DeptName = std.Dept?.DeptName ?? " No Dept! "
				//};
				var stdDTO = mapper.Map<ReadStudentDTO>(std);
				dbContext.Students.Remove(std);
				dbContext.SaveChanges();
				return Ok(stdDTO);
			}
			return BadRequest();
		}
	}
}
