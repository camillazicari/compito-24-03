using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using compito_24_03.Services;
using compito_24_03.Models;

namespace compito_24_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            var studente = await _studentService.CreateStudent(student);

            if (!studente)
            {
                return BadRequest( new
                    {
                    message = "Errore nella creazione dello studente"
                    }); 
            }
            return Ok(new
            {
                message = "Studente creato con successo"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var studentList = await _studentService.GetStudents();

            if(studentList == null)
            {
                return BadRequest(new
                {
                    message = "Errore nel recupero degli studenti"
                });
            }

            if(!studentList.Any())
            {
                return NoContent();
            }

            var count = studentList.Count;

            var text = count == 1 ? $"{count} studente trovato" : $"{count} studenti trovati";

            return Ok(new
            {
                message = text,
                data = studentList
            });
        }
    }
}
