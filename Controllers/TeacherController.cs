using Microsoft.AspNetCore.Mvc;
using smartschool_webapi.Data;
using smartschool_webapi.Models;

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

                return Ok(result != null ? result : "Professor não encontrado!");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

        [HttpGet("ByStudentId/{studentId}")]
        public async Task<IActionResult> getByDisciplineId(int studentId)
        {
            try
            {
                var result = await Repository.GetTeachersAsyncByStudentId(studentId, true);

                return Ok(result != null ? result : "Professor não encontrado!");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Teacher teacher)
        {
            try
            {
                Repository.Add(teacher);

                if (await Repository.SaveChangesAsync())
                {
                    return Ok(teacher);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{teacherId}")]
        public async Task<IActionResult> put(int teacherId, Teacher teacher)
        {
            try
            {
                var teacherFounded = await Repository.GetTeacherAsyncById(teacherId, false);
                if(teacherFounded == null) return NotFound("Professor não encontrado!");

                Repository.Update(teacher);

                if(await Repository.SaveChangesAsync())
                {
                    return Ok(teacher);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> delete(int teacherId)
        {
            try
            {
                var teacherFounded = await Repository.GetTeacherAsyncById(teacherId, false);
                if(teacherFounded == null) return NotFound("Professor não encontrado!");

                Repository.Delete(teacherFounded);

                if(await Repository.SaveChangesAsync())
                {
                    return Ok("Teacher deletado!");
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