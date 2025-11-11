using AutoMapper;
using Day01.DTOs.DepartmentDTOs;
using Day01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day01.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		ITIDbContext dbContext;
		IMapper mapper;

		public DepartmentController(ITIDbContext dbContext,IMapper _mapper)
		{
			this.dbContext = dbContext;
			mapper = _mapper;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var depts = dbContext.Departments.ToList();
			//var deptsDTO = new List<ReadDepartmentDTO>();
			//foreach (var dept in depts)
			//{
			//	deptsDTO.Add(new ReadDepartmentDTO()
			//	{
			//		Id = dept.DeptId,
			//		Location = dept.DeptLocation,
			//		Name = dept.DeptName,
			//		StudentNo = dept.Students?.Count(),
			//		StudentNames = dept.Students?.Select((s, i) => $"{i+1} - {s.StFname} {s.StLname}".Trim()) ?? new List<string>()
			//	});
			//} 
			var deptsDTO = mapper.Map<List<ReadDepartmentDTO>>(depts);
			return Ok(deptsDTO);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int? id)
		{
			if (id == null)
				return BadRequest();
			var dept = dbContext.Departments.SingleOrDefault(d => d.DeptId == id);
			if (dept == null)
				return NotFound();
			//ReadDepartmentDTO dDTO = new ReadDepartmentDTO()
			//{
			//	Id = dept.DeptId,
			//	Name = dept.DeptName,
			//	Location = dept.DeptLocation,
			//	StudentNo = dept.Students?.Count(),
			//	StudentNames = dept.Students?.Select((s, i) => $"{i + 1} - {s.StFname} {s.StLname}".Trim()) ?? new List<String>()
			//};
			ReadDepartmentDTO dDTO = mapper.Map<ReadDepartmentDTO>(dept);
			return Ok(dDTO);
		}
	}
}
