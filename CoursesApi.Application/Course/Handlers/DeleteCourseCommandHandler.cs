using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Application.Course.Commands;
using MediatR;

namespace CoursesApi.Application.Course.Handlers;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCourseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CourseRepository.RemoveAsync(request.Id);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }
}
