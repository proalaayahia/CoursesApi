using CoursesApi.Application.Course.ViewModels;
using MediatR;

namespace CoursesApi.Application.Course.Queries;

public record GetCoursesQuery() : IRequest<IEnumerable<CourseVM>>;