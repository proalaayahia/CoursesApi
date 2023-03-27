using AutoMapper;
using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Application.Course.Queries;
using CoursesApi.Application.Course.ViewModels;
using MediatR;

namespace CoursesApi.Application.Course.Handlers;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseVM>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetCoursesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CourseVM>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var data= await _unitOfWork.CourseRepository.GetAllAsync();
        var result=_mapper.Map<IEnumerable<CourseVM>>(data);
        return result;
    }
}