using Microsoft.AspNetCore.Mvc;
using StudentCourse.Domain;
using StudentCourse.Services;

namespace StudentCourse.Controlelrs;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
  private readonly CourseServices _courseServices;
  public CourseController(CourseServices courseServices)
  {
    _courseServices = courseServices;
  }

  [HttpPost]
  public IActionResult Create(createCourseRequest request)
  {
    var course = request.toDomain();
    _courseServices.Create(course);

    return Ok(course);
  }

  public record createCourseRequest(string Title, string? Description)
  {
    public Course toDomain()
    {
      return new Course
      {
        Title = Title,
        Description = Description
      };
    }
  }
}