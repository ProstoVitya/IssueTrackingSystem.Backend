using FluentValidation;

namespace IssueTrackingSystem.Application.Queries.IssuePriorities.GetIssuePriorityDetails;

public class GetIssuePriorityDetailsQueryValidator : AbstractValidator<GetIssuePriorityDetailsQuery>
{
    public GetIssuePriorityDetailsQueryValidator()
    {
        RuleFor(query => query.IssuePriorityId)
            .GreaterThan(0);
    }
}