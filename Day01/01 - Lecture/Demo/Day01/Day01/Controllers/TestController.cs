using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        //https://localhost:7179/api/test
        public string PrintHello()
        {
            return "Hello From API!";
        }
        [HttpGet("{id}")]
        //https://localhost:7179/api/test/{id}
        public string GetById(int id)
        {
            return $"Welcome {id}";
        }
    }
}
