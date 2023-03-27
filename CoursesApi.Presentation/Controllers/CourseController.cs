using CoursesApi.Application.Course.Commands;
using CoursesApi.Application.Course.Queries;
using CoursesApi.Application.Course.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ApiController
{
    [HttpGet("GetAllCourses")]
    public async Task<IEnumerable<CourseVM>> GetCoursesAsync() => await Mediator.Send(new GetCoursesQuery());

    [HttpPost("CreateCourse")]
    public async Task<int> CreateCourseAsync(CreateCourseCommand command) => await Mediator.Send(command);

    [HttpPut("EditCourse")]
    public async Task<int> EditCourseAsync(EditCourseCommand command) => await Mediator.Send(command);

    [HttpDelete("DeleteCourse")]
    public async Task<bool> DeleteCourseAsync(DeleteCourseCommand command) => await Mediator.Send(command);
}