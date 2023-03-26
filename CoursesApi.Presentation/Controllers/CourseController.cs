using CoursesApi.Application.Course.Commands;
using CoursesApi.Application.Course.Queries;
using CoursesApi.Application.Course.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ApiController
{
    [HttpGet]
    public async Task<IEnumerable<CourseVM>> GetCoursesAsync() => await Mediator.Send(new GetCoursesQuery());

    [HttpPost("CreateCourse")]
    public async Task<int> CreateCourseAsync(CreateCourseCommand command) => await Mediator.Send(command);
}