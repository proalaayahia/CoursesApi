using MediatR;

namespace CoursesApi.Application.Course.Commands;

public class DeleteCourseCommand:IRequest<bool>
{
    public int Id { get; set; }
}
