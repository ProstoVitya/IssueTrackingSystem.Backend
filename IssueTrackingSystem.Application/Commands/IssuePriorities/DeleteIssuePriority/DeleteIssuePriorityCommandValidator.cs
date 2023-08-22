using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.IssuePriorities.DeleteIssuePriority;

public class DeleteIssuePriorityCommandValidator : AbstractValidator<DeleteIssuePriorityCommand>
{
    public DeleteIssuePriorityCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);
    }
}