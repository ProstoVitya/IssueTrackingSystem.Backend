using FluentValidation;

namespace IssueTrackingSystem.Application.Queries.Users.GetUserList;

public class GetUserListQueryValidator : AbstractValidator<GetUserListQuery>
{
    public GetUserListQueryValidator()
    {
        RuleFor(query => query.ProjectId)
            .GreaterThan(0);
    }
}