using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Projects.DeleteProject;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);
    }
}