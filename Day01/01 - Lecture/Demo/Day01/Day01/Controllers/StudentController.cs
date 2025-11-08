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

        public StudentController(ITIDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        [HttpGet]
        public List<Student> GetAll()
        {
            return dbContext.Students.ToList();
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int? id)
        {
            if (id == null)
                return BadRequest();
            var std = dbContext.Students.SingleOrDefault(s => s.StId == id);
            if (std == null)
                return NotFound();
            return Ok(std);
        }
        //[HttpGet("/api/student/name/{name}")]
        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            if (name == null)
                return BadRequest();
            var std = dbContext.Students.SingleOrDefault(s => s.StFname == name);
            if (std == null)
                return NotFound();
            return Ok(std);
        }
        [HttpPost]
        public IActionResult Add(Student std)
        {
            if (std == null)
                return BadRequest();
            if (ModelState.IsValid)
            {
                dbContext.Students.Add(std);
                dbContext.SaveChanges();
                return CreatedAtAction("GetById", new { id = std.StId }, std);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Student std)
        {
            if (std == null)
                return BadRequest();
            if (id != std.StId)
                return BadRequest();
            var student = dbContext.Students.AsNoTracking().SingleOrDefault(s => s.StId == id);
            if (student == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                dbContext.Students.Update(std);
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
                dbContext.Students.Remove(std);
                dbContext.SaveChanges();
                return Ok(std);
            }
            return BadRequest();
        }
    }
}
