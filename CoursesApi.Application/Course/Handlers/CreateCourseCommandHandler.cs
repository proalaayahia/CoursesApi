using AutoMapper;
using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Application.Course.Commands;
using FluentValidation;
using MediatR;

namespace CoursesApi.Application.Course.Handlers;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var source = _mapper.Map<CoursesApi.Domain.Entities.Course>(request);
        await _unitOfWork.CourseRepository.AddAsync(source);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return 0;
    }
}