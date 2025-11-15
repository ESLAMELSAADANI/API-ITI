using AutoMapper;
using Day01.DTOs.DepartmentDTOs;
using Day01.Models;
using Day01.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Day01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IEntityRepo<Department> departmentRepo;
        IMapper mapper;

        public DepartmentController(IEntityRepo<Department> _departmentRepo, IMapper _mapper)
        {
            departmentRepo = _departmentRepo;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var depts = departmentRepo.GetAll();
            var deptsDTO = mapper.Map<List<ReadDepartmentDTO>>(depts);
            return Ok(deptsDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if (id == null)
                return BadRequest();
            var dept = departmentRepo.GetById<int>(id.Value);
            if (dept == null)
                return NotFound();
            ReadDepartmentDTO dDTO = mapper.Map<ReadDepartmentDTO>(dept);
            return Ok(dDTO);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult Add(AddDepartmentDTO departmentDTO)
        {
            if (departmentDTO == null)
                return BadRequest();
            if (ModelState.IsValid)
            {
                Department dept = mapper.Map<Department>(departmentDTO);
                departmentRepo.Add(dept);
                departmentRepo.SaveChanges();
                return RedirectToAction("GetById", new { id = dept.DeptId });
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int? id, AddDepartmentDTO departmentDTO)
        {
            if (id == null || departmentDTO == null || id != departmentDTO.Id)
                return BadRequest();
            Department department = departmentRepo.GetById<int>(id.Value);
            if (department == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                Department dept = mapper.Map<Department>(departmentDTO);
                departmentRepo.Edit(dept);
                departmentRepo.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            Department dept = departmentRepo.GetById<int>(id.Value);
            if (dept == null)
                return NotFound();
            departmentRepo.Delete(dept);
            departmentRepo.SaveChanges();
            var deptDTO = mapper.Map<ReadDepartmentDTO>(dept);
            return Ok(deptDTO);
        }

    }
}
