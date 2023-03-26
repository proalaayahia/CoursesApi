using CoursesApi.Domain.Entities;
using CoursesApi.Domain.Entities.Common;
using CoursesApi.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Infrastructure.Data;

public class ApplicationDbContext:IdentityDbContext<ApplicationUser,IdentityRole,string>,IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditEntity>())
        {
            switch(entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = "Aladdin";
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = "Aladdin";
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
