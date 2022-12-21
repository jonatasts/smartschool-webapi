using Microsoft.AspNetCore.Mvc;
using smartschool_webapi.Data;

namespace smartschool_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        public readonly IRepository Repository;
        public TeacherController(IRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await Repository.GetAllTeachersAsync(true);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacherById(int teacherId)
        {
            try
            {
                var result = await Repository.GetTeacherAsyncById(teacherId, true);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
    }
}