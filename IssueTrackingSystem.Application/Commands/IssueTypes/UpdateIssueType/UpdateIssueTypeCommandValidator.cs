using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.IssueTypes.UpdateIssueType;

public class UpdateIssueTypeCommandValidator : AbstractValidator<UpdateIssueTypeCommand>
{
    public UpdateIssueTypeCommandValidator()
    {
        RuleFor(updateIssueTypeCommand => updateIssueTypeCommand.Id)
            .GreaterThan(0);
        RuleFor(updateIssueTypeCommand => updateIssueTypeCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }
}