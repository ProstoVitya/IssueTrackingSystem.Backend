using FluentValidation;

namespace IssueTrackingSystem.Application.Queries.Projects.GetProjectDetails;

public class GetProjectDetailsQueryValidator : AbstractValidator<GetProjectDetailsQuery>
{
    public GetProjectDetailsQueryValidator()
    {
        RuleFor(query => query.ProjectId)
            .GreaterThan(0);
    }
}