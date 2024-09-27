namespace StudentCourse.Domain;

public class Student 
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public required string Name { get; set; }
  public string? Email { get; set; }
  public List<Course> Courses { get; set; } = new List<Course>();
}