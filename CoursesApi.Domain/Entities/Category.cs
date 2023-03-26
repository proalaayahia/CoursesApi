namespace CoursesApi.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Course> Courses { get; set; } = null!;
}
