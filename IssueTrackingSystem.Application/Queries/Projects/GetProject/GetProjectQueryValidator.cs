using FluentValidation;

namespace IssueTrackingSystem.Application.Queries.Projects.GetProject;

public class GetProjectQueryValidator : AbstractValidator<GetProjectQuery>
{
    public GetProjectQueryValidator()
    {
        RuleFor(query => query.ProjectId)
            .GreaterThan(0);
    }
}