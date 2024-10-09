using Courses.Domain.Entities;
using Courses.Domain.Interfaces;

namespace Courses.Infrastrutre.Repositories
{
  public class CourseRepository : ICoursetRepository
  {
    private List<Course> _courses = new List<Course>();

    public List<Course> GetCourses() => _courses;

    public Course? GetCourseById(Guid id) => _courses.FirstOrDefault(x => x.Id == id);

    public void AddCourse(Course course) => _courses.Add(course);

    public void UpdateCourse(Course course)
    {
      var existingCourse = _courses.FirstOrDefault(x => x.Id == course.Id);
      if (existingCourse != null)
      {
        existingCourse.Title = course.Title;
      }
    }

    public void DeleteCourse(Guid id)
    {
      var course = _courses.FirstOrDefault(x => x.Id == id);
      if (course != null)
      {
        _courses.Remove(course);
      }
    }
    
  }
}