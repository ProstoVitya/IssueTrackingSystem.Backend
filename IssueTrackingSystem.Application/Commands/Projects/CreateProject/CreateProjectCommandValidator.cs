using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Projects.CreateProject;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(createProjectCommand => createProjectCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }
}