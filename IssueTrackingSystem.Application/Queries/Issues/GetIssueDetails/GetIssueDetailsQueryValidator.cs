using FluentValidation;

namespace IssueTrackingSystem.Application.Queries.Issues.GetIssueDetails;

public class GetIssueDetailsQueryValidator : AbstractValidator<GetIssueDetailsQuery>
{
    public GetIssueDetailsQueryValidator()
    {
        RuleFor(query => query.ProjectId)
            .GreaterThan(0);
        RuleFor(query => query.IssueIndex)
            .GreaterThan(0);
    }
}