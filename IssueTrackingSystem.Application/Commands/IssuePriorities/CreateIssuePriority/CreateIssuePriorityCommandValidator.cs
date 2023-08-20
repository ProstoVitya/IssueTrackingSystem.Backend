using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.IssuePriorities.CreateIssuePriority;

public class CreateIssuePriorityCommandValidator : AbstractValidator<CreateIssuePriorityCommand>
{
    public CreateIssuePriorityCommandValidator()
    {
        RuleFor(createIssuePriorityCommand => createIssuePriorityCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }
}