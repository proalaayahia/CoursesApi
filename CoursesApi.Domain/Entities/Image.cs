namespace CoursesApi.Domain.Entities;

public class Image
{
    public int Id { get; set; }
    public string FileName { get; set; } = null!;
    public string StoredFileName { get; set; } = null!;
    public string ContentType { get; set; } = null!;
}
