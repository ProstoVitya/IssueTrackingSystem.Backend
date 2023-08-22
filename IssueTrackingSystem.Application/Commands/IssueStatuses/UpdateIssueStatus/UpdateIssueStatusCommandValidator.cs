using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.IssueStatuses.UpdateIssueStatus;

public class UpdateIssueStatusCommandValidator : AbstractValidator<UpdateIssueStatusCommand>
{
    public UpdateIssueStatusCommandValidator()
    {
        RuleFor(updateIssueStatusCommand => updateIssueStatusCommand.Id)
            .GreaterThan(0);
        RuleFor(updateIssueStatusCommand => updateIssueStatusCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }
}