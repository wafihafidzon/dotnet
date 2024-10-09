using Courses.Domain.Entities;

namespace Courses.Domain.Interfaces
{
  public interface ICoursetRepository
  {
    List<Course> GetCourses();
    Course? GetCourseById(Guid id);
    void AddCourse(Course course);
    void UpdateCourse(Course course);
    void DeleteCourse(Guid id);
  }
}