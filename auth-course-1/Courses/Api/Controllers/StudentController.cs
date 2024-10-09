using Microsoft.AspNetCore.Mvc;
using Courses.Application.Services;
using Courses.Domain.Entities;

namespace Courses.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StudentController : ControllerBase
  {
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
      _studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetAllStudents() => Ok(_studentService.GetStudents());

    [HttpGet("{id}")]
    public IActionResult GetStudentById(Guid id)
    {
      var student = _studentService.GetStudentById(id);
      if (student == null) return NotFound();
      return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
      _studentService.AddStudent(student);
      return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(Guid id, Student student)
    {
      var existingStudent = _studentService.GetStudentById(id);
      if (existingStudent == null) return NotFound();

      student.Id = id;
      _studentService.UpdateStudent(student);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(Guid id)
    {
      var student = _studentService.GetStudentById(id);
      if (student == null) return NotFound();

      _studentService.DeleteStudent(id);
      return NoContent();
    }
  }
}
