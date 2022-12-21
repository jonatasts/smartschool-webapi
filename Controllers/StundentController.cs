using Microsoft.AspNetCore.Mvc;
using smartschool_webapi.Data;

namespace smartschool_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public readonly IRepository Repository;
        public StudentController(IRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await Repository.GetAllStudentsAsync(true);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            try
            {
                var result = await Repository.GetStudentAsyncById(studentId, true);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
    }
}