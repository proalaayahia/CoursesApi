using CoursesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Infrastructure.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Course> Courses { get; }
    DbSet<Category> Categories { get; }
    DbSet<Image> Images { get; }
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    ValueTask DisposeAsync();
}
