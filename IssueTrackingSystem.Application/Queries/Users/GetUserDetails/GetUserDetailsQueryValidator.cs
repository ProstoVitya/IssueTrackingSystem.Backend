using FluentValidation;
using IssueTrackingSystem.Application.Queries.Projects.GetProject;

namespace IssueTrackingSystem.Application.Queries.Users.GetUserDetails;

public class GetUserDetailsQueryValidator : AbstractValidator<GetProjectQuery>
{
    public GetUserDetailsQueryValidator()
    {
        RuleFor(query => query.ProjectId)
            .GreaterThan(0);
    }
}