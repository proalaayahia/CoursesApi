namespace CoursesApi.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; } = null!;
    public string? Description { get; set; }
    public Category Category { get; set; } = null!;
    public Image? image { get; set; }
}
