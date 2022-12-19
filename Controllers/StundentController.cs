using Microsoft.AspNetCore.Mvc;

namespace smartschool_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
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