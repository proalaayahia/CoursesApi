﻿using MediatR;

namespace CoursesApi.Application.Course.Commands;

public class CreateCourseCommand : IRequest<int>
{
    public string CourseName { get; set; } = null!;
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public int? imageId { get; set; }
}