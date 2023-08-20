using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Issues.UpdateIssue;

public class UpdateIssueCommandValidator : AbstractValidator<UpdateIssueCommand>
{
    public UpdateIssueCommandValidator()
    {
        RuleFor(updateIssueCommand => updateIssueCommand.Name)
            .NotEmpty();
        RuleFor(updateIssueCommand => updateIssueCommand.Finished)
            .Must(date => date == null || date.Value >= DateTime.Now);
        RuleFor(updateIssueCommand => updateIssueCommand.StoryPoints)
            .GreaterThan(0);
        RuleFor(updateIssueCommand => updateIssueCommand.AssigneeId)
            .NotEqual(Guid.Empty);
        RuleFor(updateIssueCommand => updateIssueCommand.IssueTypeId)
            .GreaterThan(0);
        RuleFor(updateIssueCommand => updateIssueCommand.PriorityId)
            .GreaterThan(0);
        RuleFor(updateIssueCommand => updateIssueCommand.StatusId)
            .GreaterThan(0);
    }
}