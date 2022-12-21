using Microsoft.AspNetCore.Mvc;
using smartschool_webapi.Data;

namespace smartschool_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public IRepository Repository { get; }
        public StudentController(IRepository repository)
        {
            this.Repository = repository;            
        }

        [HttpGet]
        public IActionResult get()
        {
            try
            {
                return Ok("Jonatas");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
    }
}