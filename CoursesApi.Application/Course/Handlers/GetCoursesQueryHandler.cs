using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Application.Course.Queries;
using CoursesApi.Application.Course.ViewModels;
using MediatR;

namespace CoursesApi.Application.Course.Handlers;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseVM>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCoursesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<CourseVM>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.CourseReposVm.GetAllAsync();
    }
}