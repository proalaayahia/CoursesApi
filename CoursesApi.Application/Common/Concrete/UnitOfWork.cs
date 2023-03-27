using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Infrastructure.Interfaces;

namespace CoursesApi.Application.Common.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _context;

    public UnitOfWork(IApplicationDbContext context)
    {
        _context = context;
        CourseRepository=new Repository<CoursesApi.Domain.Entities.Course>(context);
    }

    public IRepository<Domain.Entities.Course> CourseRepository { get; private set; }

    public Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }
}
