using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.IssuePriorities.UpdateIssuePriority;

public class UpdateIssuePriorityCommandValidator : AbstractValidator<UpdateIssuePriorityCommand>
{
    public UpdateIssuePriorityCommandValidator()
    {
        RuleFor(updateIssuePriorityCommand => updateIssuePriorityCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }
}