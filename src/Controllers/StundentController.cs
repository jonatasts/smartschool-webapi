using Microsoft.AspNetCore.Mvc;
using smartschool_webapi.Data;
using smartschool_webapi.Models;

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

                return Ok(result != null ? result : new { message = "Aluno não encontrado!" });
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

        [HttpGet("ByDisciplineId/{disciplineId}")]
        public async Task<IActionResult> getByDisciplineId(int disciplineId)
        {
            try
            {
                var result = await Repository.GetStudentsAsyncByDisciplineId(disciplineId, true);

                return Ok(result != null ? result : new { message = "Aluno não encontrado!" });
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Student student)
        {
            try
            {
                Repository.Add(student);

                if (await Repository.SaveChangesAsync())
                {
                    return Ok(student);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> put(int studentId, Student student)
        {
            try
            {
                var studentFounded = await Repository.GetStudentAsyncById(studentId, false);
                if (studentFounded == null) return NotFound(new { message = "Aluno não encontrado!" });

                Repository.Update(student);

                if (await Repository.SaveChangesAsync())
                {
                    return Ok(student);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> delete(int studentId)
        {
            try
            {
                var studentFounded = await Repository.GetStudentAsyncById(studentId, false);
                if (studentFounded == null) return NotFound("Aluno não encontrado!");

                Repository.Delete(studentFounded);

                if (await Repository.SaveChangesAsync())
                {
                    return Ok(new { message = "Aluno deletado!" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}