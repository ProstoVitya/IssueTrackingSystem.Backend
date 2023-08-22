using FluentValidation;

namespace IssueTrackingSystem.Application.Queries.Issues.GetIssueList;

public class GetIssueListQueryValidator : AbstractValidator<GetIssueListQuery>
{
    public GetIssueListQueryValidator()
    {
        //TODO: придумать как обработать, чтобы можно было либо по пользователю выбирать либо по проекту
    }
}