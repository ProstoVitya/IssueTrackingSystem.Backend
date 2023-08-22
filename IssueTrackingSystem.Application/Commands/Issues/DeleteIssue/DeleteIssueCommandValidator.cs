using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Issues.DeleteIssue;

public class DeleteIssueCommandValidator : AbstractValidator<DeleteIssueCommand>
{
    public DeleteIssueCommandValidator()
    {
        RuleFor(command => command.IssueIndex)
            .GreaterThan(0);
        RuleFor(command => command.ProjectId)
            .GreaterThan(0);
    }
}