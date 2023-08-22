using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.IssueStatuses.DeleteIssueStatus;

public class DeleteIssueStatusCommandValidator : AbstractValidator<DeleteIssueStatusCommand>
{
    public DeleteIssueStatusCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);
    }
}