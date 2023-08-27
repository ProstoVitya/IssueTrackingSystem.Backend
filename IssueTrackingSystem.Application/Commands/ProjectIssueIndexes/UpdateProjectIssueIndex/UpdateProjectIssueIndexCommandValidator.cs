using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.UpdateProjectIssueIndex;

public class UpdateProjectIssueIndexCommandValidator : AbstractValidator<UpdateProjectIssueIndexCommand>
{
    public UpdateProjectIssueIndexCommandValidator()
    {
        RuleFor(command => command.ProjectId)
            .GreaterThan(0);
    }
}