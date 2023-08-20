using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Issues.CreateIssue;

public class CreateIssueCommandValidator : AbstractValidator<CreateIssueCommand>
{
    public CreateIssueCommandValidator()
    {
        RuleFor(createIssueCommand => createIssueCommand.Name)
            .NotEmpty();
        RuleFor(createIssueCommand => createIssueCommand.AssigneeId)
            .NotEqual(Guid.Empty);
        RuleFor(createIssueCommand => createIssueCommand.AssigneeId)
            .NotEqual(Guid.Empty);
    }
}