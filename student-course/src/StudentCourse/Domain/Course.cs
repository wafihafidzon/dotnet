namespace StudentCourse.Domain;

public class Course
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public required string Title { get; set; }
  public string? Description { get; set; }
  public List<Student> students { get; set; } = new List<Student>();
}