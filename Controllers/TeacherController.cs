using Microsoft.AspNetCore.Mvc;

namespace smartschool_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            try
            {
                return Ok("Vinicius");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
    }
}