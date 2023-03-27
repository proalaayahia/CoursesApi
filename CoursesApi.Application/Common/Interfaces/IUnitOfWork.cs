namespace CoursesApi.Application.Common.Interfaces;

public interface IUnitOfWork:IAsyncDisposable
{
    IRepository<CoursesApi.Domain.Entities.Course> CourseRepository { get; }
    Task<int> CompleteAsync(CancellationToken cancellationToken);
}
