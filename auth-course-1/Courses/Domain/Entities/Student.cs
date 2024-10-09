namespace Courses.Domain.Entities
{
  public class Student
  {
    public Guid Id { get; set; } = new Guid();
    public required string Name { get; set; }
    public required string Email { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
  }
}