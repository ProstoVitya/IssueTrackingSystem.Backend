using FluentValidation;

namespace IssueTrackingSystem.Application.Queries.IssueTypes.GetIssueTypeDetails;

public class GetIssueTypeDetailsQueryValidator : AbstractValidator<GetIssueTypeDetailsQuery>
{
    public GetIssueTypeDetailsQueryValidator()
    {
        RuleFor(query => query.IssueTypeId)
            .GreaterThan(0);
    }
}