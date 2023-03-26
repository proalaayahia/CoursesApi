using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Presentation.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    private IMediator? mediator;
    protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
}