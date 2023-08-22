using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.IssueTypes.DeleteIssueType;

public class DeleteIssueTypeCommandValidator : AbstractValidator<DeleteIssueTypeCommand>
{
    public DeleteIssueTypeCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);
    }
}