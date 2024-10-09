using Courses.Domain.Entities;
using Courses.Domain.Interfaces;

namespace Courses.Application.Services
{
  public class CourseService
  {
    private readonly ICoursetRepository _courseRepository;

    public CourseService(ICoursetRepository courseRepository)
    {
      _courseRepository = courseRepository;
    }

    public List<Course> GetCourses() => _courseRepository.GetCourses();
    public Course? GetCourseById(Guid id) => _courseRepository.GetCourseById(id);
    public void AddCourse(Course course) => _courseRepository.AddCourse(course);
    public void UpdateCourse(Course course) => _courseRepository.UpdateCourse(course);
    public void DeleteCourse(Guid id) => _courseRepository.DeleteCourse(id);
  }
}