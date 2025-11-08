using Day01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        ITIDbContext dbContext;
        public TopicController(ITIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var topics = dbContext.Topics.ToList();
            if (topics != null && topics.Count > 0)
                return Ok(topics);
            return NotFound();
        }
    }
}
