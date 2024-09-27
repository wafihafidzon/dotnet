using Microsoft.AspNetCore.Mvc;
using StudentCourse.Domain;
using StudentCourse.Services;

namespace StudentCourse.Controlelrs;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
  private readonly StudentServices _studentServices;
  private readonly CourseServices _courseServices;

  public StudentController(StudentServices studentServices, CourseServices courseServices)
  {
    _studentServices = studentServices;
    _courseServices = courseServices;
  }

  [HttpPost]
  public IActionResult Create(createStudentRequest request)
  {
    var student = request.toDomain();

    Console.WriteLine(request.Name);
    _studentServices.Create(student);
    return Ok(student);
  }

  [HttpPost("{studentId:guid}/courses/{courseId:guid}")]
  public IActionResult AddCourse(Guid studentId, Guid courseId)
  {
    var course = _courseServices.GetById(courseId);
    if (course == null)
    {
      return Problem(statusCode: StatusCodes.Status404NotFound, detail: "Course Not Found");
    }
    var student = _studentServices.GetById(studentId);
    if (student == null)
    {
      return Problem(statusCode: StatusCodes.Status404NotFound, detail: "Student");
    }
    
    _studentServices.AddCourse(student, course);
    return Ok();
  }
  public record createStudentRequest(string Name, string? Email)
  {
    public Student toDomain()
    
    {
      return new Student
      {
        Name = Name,
        Email = Email
      };
    }
  }
}