using CoursesApi.Application.Course.Commands;
using FluentValidation;

namespace CoursesApi.Application.Course.Validators;

public class EditCourseCommandValidator:AbstractValidator<EditCourseCommand>
{
    public EditCourseCommandValidator()
    {
        RuleFor(v=>v.CourseName).NotEmpty();
        RuleFor(v=>v.Description).NotEmpty();
    }
}
