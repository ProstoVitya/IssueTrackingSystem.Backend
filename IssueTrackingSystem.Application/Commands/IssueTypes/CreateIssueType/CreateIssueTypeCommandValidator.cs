using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.IssueTypes.CreateIssueType;

public class CreateIssueTypeCommandValidator : AbstractValidator<CreateIssueTypeCommand>
{
    public CreateIssueTypeCommandValidator()
    {
        RuleFor(createIssueTypeCommand => createIssueTypeCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }
}