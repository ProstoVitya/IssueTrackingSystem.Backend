using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.DeleteProjectIssueIndex;

public class DeleteProjectIssueIndexCommandValidator : AbstractValidator<DeleteProjectIssueIndexCommand>
{
    public DeleteProjectIssueIndexCommandValidator()
    {
        RuleFor(command => command.ProjectId)
            .GreaterThan(0);
    }
}