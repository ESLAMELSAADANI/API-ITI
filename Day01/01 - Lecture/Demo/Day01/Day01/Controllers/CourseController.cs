using Day01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ITIDbContext dbContext;

        public CourseController(ITIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var courses = dbContext.Courses.ToList();
            if (courses != null && courses.Count > 0)
                return Ok(courses);
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = dbContext.Courses.SingleOrDefault(c => c.CrsId == id);
            if (course == null)
                return NotFound();//404
            dbContext.Remove(course);
            dbContext.SaveChanges();
            return Ok(course);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Course crs)
        {
            if (crs == null)
                return BadRequest();
            if (id != crs.CrsId)
                return BadRequest();//400
            if (ModelState.IsValid)
            {
                dbContext.Courses.Update(crs);
                dbContext.SaveChanges();
                return NoContent();//204
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Post(Course crs)
        {
            if (crs == null)
                return BadRequest();//400
            if (ModelState.IsValid)
            {
                dbContext.Courses.Add(crs);
                dbContext.SaveChanges();
                return Ok(crs);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var crs = dbContext.Courses.SingleOrDefault(c => c.CrsId == id);
            if (crs == null)
                return NotFound();//404
            return Ok(crs);
        }
        [HttpGet("/api/course/name/{name}")]
        public IActionResult GetByName(string name)
        {
            var crs = dbContext.Courses.SingleOrDefault(c => c.CrsName == name);
            if (crs == null)
                return NotFound();//404
            return Ok(crs);
        }

    }
}
