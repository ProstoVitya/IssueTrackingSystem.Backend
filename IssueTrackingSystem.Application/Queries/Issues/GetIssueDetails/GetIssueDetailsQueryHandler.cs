using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Queries.Issues.GetIssueDetails;

public class GetIssueDetailsQueryHandler : IRequestHandler<GetIssueDetailsQuery, Issue>
{
    private readonly IIssueDbContext _dbContext;

    public GetIssueDetailsQueryHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Issue> Handle(GetIssueDetailsQuery request, CancellationToken cancellationToken)
    {
        var issue = await GetIssueAsync(request, cancellationToken);
        return issue;
    }
    
    private async Task<Issue> GetIssueAsync(GetIssueDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Issues.FirstOrDefaultAsync(issue =>
            new { issue.ProjectId, IssueIndex = issue.Index } == new { request.ProjectId, request.IssueIndex },
            cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Issue), new { Index = request.IssueIndex, request.ProjectId });
        }

        return entity;
    }
}