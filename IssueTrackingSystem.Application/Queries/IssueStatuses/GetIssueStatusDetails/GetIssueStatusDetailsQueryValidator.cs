using FluentValidation;

namespace IssueTrackingSystem.Application.Queries.IssueStatuses.GetIssueStatusDetails;

public class GetIssueStatusDetailsQueryValidator : AbstractValidator<GetIssueStatusDetailsQuery>
{
    public GetIssueStatusDetailsQueryValidator()
    {
        RuleFor(query => query.IssueStatusId)
            .GreaterThan(0);
    }
}