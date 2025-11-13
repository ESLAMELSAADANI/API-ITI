using AutoMapper;
using Day01.DTOs.CourseDTOs;
using Day01.DTOs.StudentDTOs;
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
        IMapper mapper;

        public CourseController(ITIDbContext dbContext, IMapper _mapper)
        {
            this.dbContext = dbContext;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var courses = dbContext.Courses.ToList();
            if (courses == null || courses.Count == 0)
                return NotFound();
            List<ReadCourseDTO> courseDTOs = mapper.Map<List<ReadCourseDTO>>(courses);
            return Ok(new
            {
                message = "Courses Retrieved Successfully!",
                courses = dbContext.Courses.Count(),
                data = courseDTOs
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = dbContext.Courses.SingleOrDefault(c => c.CrsId == id);
            if (course == null)
                return NotFound();//404
            var courseDTO = mapper.Map<ReadCourseDTO>(course);
            dbContext.Remove(course);
            dbContext.SaveChanges();
            return Ok(new
            {
                message = "Course Deleted Successfully!",
                deletedCourse = courseDTO
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AddCourseDTO crsDTO)
        {
            if (crsDTO == null || id != crsDTO.CrsId)
                return BadRequest();//400
            if (ModelState.IsValid)
            {
                var crs = mapper.Map<Course>(crsDTO);
                dbContext.Courses.Update(crs);
                dbContext.SaveChanges();
                return NoContent();//204
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Post(AddCourseDTO crsDTO)
        {
            if (crsDTO == null)
                return BadRequest();//400
            if (ModelState.IsValid)
            {
                var crs = mapper.Map<Course>(crsDTO);
                dbContext.Courses.Add(crs);
                dbContext.SaveChanges();
                return Ok(new
                {
                    message = "Course Added successfully!",
                    course = crsDTO

                });
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if (id == null)
                return BadRequest();
            var crs = dbContext.Courses.SingleOrDefault(c => c.CrsId == id);
            if (crs == null)
                return NotFound();//404
            //Console.WriteLine(crs.Top.TopName);
            var courseDTO = mapper.Map<ReadCourseDTO>(crs);
            return Ok(new
            {
                message = "Course Retrieved Successfully!",
                data = courseDTO
            });
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
