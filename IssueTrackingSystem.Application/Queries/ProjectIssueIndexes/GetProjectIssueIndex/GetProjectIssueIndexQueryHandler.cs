using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Queries.ProjectIssueIndexes.GetProjectIssueIndex;

public class GetProjectIssueIndexQueryHandler : IRequestHandler<GetProjectIssueIndexQuery, ProjectIssueIndex>
{
    private readonly IIssueDbContext _dbContext;

    public GetProjectIssueIndexQueryHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProjectIssueIndex> Handle(GetProjectIssueIndexQuery request, CancellationToken cancellationToken)
    {
        var index = await GetProjectIssueIndexAsync(request.ProjectId, cancellationToken);
        return index;
    }

    private async Task<ProjectIssueIndex> GetProjectIssueIndexAsync(int projectId, CancellationToken cancellationToken)
    {
        var index = await _dbContext.ProjectIssueIndexes.FirstOrDefaultAsync(i => i.Project.Id == projectId,
            cancellationToken);
        if(index == null)
        {
            throw new NotFoundException(nameof(ProjectIssueIndex), projectId);
        }

        return index;
    }
}