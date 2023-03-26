using CoursesApi.Application.Course.Commands;
using CoursesApi.Application.Course.ViewModels;

namespace CoursesApi.Application.Common.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<CoursesApi.Domain.Entities.Course, CreateCourseCommand> CourseRepository { get; }
    IRepository<CoursesApi.Domain.Entities.Course, CourseVM> CourseReposVm { get; }

    Task<int> CompleteAsync(CancellationToken cancellationToken);
}