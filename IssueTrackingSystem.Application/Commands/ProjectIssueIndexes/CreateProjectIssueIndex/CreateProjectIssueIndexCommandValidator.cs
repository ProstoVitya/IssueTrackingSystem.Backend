using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.CreateProjectIssueIndex;

public class CreateProjectIssueIndexCommandValidator : AbstractValidator<CreateProjectIssueIndexCommand>
{
    public CreateProjectIssueIndexCommandValidator()
    {
        RuleFor(command => command.ProjectId)
            .GreaterThan(0);
    }
}