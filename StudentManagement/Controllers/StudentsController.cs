using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentService studentService, ILogger<StudentsController> logger)//, ILogger<StudentsController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        //Get All the Students details
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            _logger.LogInformation("GetStudents called at {time}", DateTime.UtcNow);
            var students = await _studentService.GetAllStudentsAsync().ConfigureAwait(false);
            return Ok(students);
        }

        //Get Student details by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        //Create a new Student
        [HttpPost]

        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _studentService.CreateAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
          var update = await _studentService.UpdateStudentAsync(id, student);
            if (!update)
                return NotFound();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStudent(int id, [FromBody] StudentPatchDTO student)
        {
            var patched = await _studentService.PatchAsync(id, student);
            if (!patched)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)

        {
            var deleted = await _studentService.DeleteStudentAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
