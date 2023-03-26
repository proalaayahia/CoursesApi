using AutoMapper;
using CoursesApi.Application.Course.Commands;
using CoursesApi.Application.Course.ViewModels;

namespace CoursesApi.Application.Course.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CoursesApi.Domain.Entities.Course, CreateCourseCommand>()
        .ForMember(m => m.CategoryId, p => p.MapFrom(opt => opt.Category.Id))
        .ForMember(m => m.imageId, p => p.MapFrom(opt => opt.image!.Id)).ReverseMap();

        CreateMap<CoursesApi.Domain.Entities.Course, CourseVM>()
        .ForMember(m => m.CategoryId, p => p.MapFrom(opt => opt.Category.Id))
        .ForMember(m => m.imageId, p => p.MapFrom(opt => opt.image!.Id)).ReverseMap();

    }
}