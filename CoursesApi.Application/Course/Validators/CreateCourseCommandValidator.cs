using CoursesApi.Application.Course.Commands;
using FluentValidation;

namespace CoursesApi.Application.Course.Validators;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(v => v.CourseName).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(v => v.Description).MaximumLength(250);
    }
}