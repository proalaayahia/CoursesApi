using AutoMapper;
using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Application.Course.Commands;
using MediatR;

namespace CoursesApi.Application.Course.Handlers;

public class EditCourseCommandHandler : IRequestHandler<EditCourseCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EditCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Handle(EditCourseCommand request, CancellationToken cancellationToken)
    {
        var source = _mapper.Map<CoursesApi.Domain.Entities.Course>(request);
        _unitOfWork.CourseRepository.Update(source);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return request.Id;
    }
}
