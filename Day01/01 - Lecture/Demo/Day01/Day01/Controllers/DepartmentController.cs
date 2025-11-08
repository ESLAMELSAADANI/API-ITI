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

        public DepartmentController(ITIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var depts = dbContext.Departments.ToList();
            if (depts == null || depts.Count == 0)
                return NotFound();
            return Ok(depts);
        }
    }
}
