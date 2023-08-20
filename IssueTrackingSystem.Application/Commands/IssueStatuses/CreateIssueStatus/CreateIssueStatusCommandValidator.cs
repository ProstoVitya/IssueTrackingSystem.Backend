using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.IssueStatuses.CreateIssueStatus;

public class CreateIssueStatusCommandValidator : AbstractValidator<CreateIssueStatusCommand>
{
    public CreateIssueStatusCommandValidator()
    {
        RuleFor(createIssueStatusCommand => createIssueStatusCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }
}