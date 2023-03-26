using Microsoft.AspNetCore.Identity;

namespace CoursesApi.Infrastructure.Data;

public class ApplicationUser:IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public string? Address { get; set; }
}
