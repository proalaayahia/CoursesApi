using AutoMapper;
using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Application.Course.Commands;
using CoursesApi.Application.Course.ViewModels;
using CoursesApi.Infrastructure.Interfaces;

namespace CoursesApi.Application.Common.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public UnitOfWork(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        CourseRepository = new Repository<CoursesApi.Domain.Entities.Course, CreateCourseCommand>(context, mapper);
        CourseReposVm = new Repository<CoursesApi.Domain.Entities.Course, CourseVM>(context, mapper);
    }
    public IRepository<Domain.Entities.Course, CreateCourseCommand> CourseRepository { get; private set; }
    public IRepository<Domain.Entities.Course, CourseVM> CourseReposVm { get; private set; }
    public async Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }
}