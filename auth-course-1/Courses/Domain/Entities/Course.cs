namespace Courses.Domain.Entities
{
  public class Course
  {
    public Guid Id { get; set; } = new Guid();
    public required string Title { get; set; }
  }
}