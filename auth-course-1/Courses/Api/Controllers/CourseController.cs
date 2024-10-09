using Microsoft.AspNetCore.Mvc;
using Courses.Application.Services;
using Courses.Domain.Entities;

namespace Courses.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CourseController : ControllerBase
  {
    private readonly CourseService _courseService;

    public CourseController(CourseService courseService)
    {
      _courseService = courseService;
    }

    [HttpGet]
    public IActionResult GetAllCourses() => Ok(_courseService.GetCourses());

    [HttpGet("{id}")]
    public IActionResult GetCourseById(Guid id)
    {
      var course = _courseService.GetCourseById(id);
      if (course == null) return NotFound();
      return Ok(course);
    }

    [HttpPost]
    public IActionResult AddCourse(Course course)
    {
      _courseService.AddCourse(course);
      return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCourse(Guid id, Course course)
    {
      var existingCourse = _courseService.GetCourseById(id);
      if (existingCourse == null) return NotFound();

      course.Id = id;
      _courseService.UpdateCourse(course);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCourse(Guid id)
    {
      var course = _courseService.GetCourseById(id);
      if (course == null) return NotFound();

      _courseService.DeleteCourse(id);
      return NoContent();
    }
  }
}
