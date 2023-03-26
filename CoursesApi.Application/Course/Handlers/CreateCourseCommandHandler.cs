using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Application.Course.Commands;
using MediatR;

namespace CoursesApi.Application.Course.Handlers;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateCourseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CourseRepository.AddAsync(request);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return 0;
    }
}