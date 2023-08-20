using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Queries.Projects.GetProject;

public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, Project>
{
    private readonly IIssueDbContext _dbContext;

    public GetProjectQueryHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Project> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        var project = await GetProjectByIdAsync(request.ProjectId, cancellationToken);
        return project;
    }

    private async Task<Project> GetProjectByIdAsync(int projectId, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == projectId,
            cancellationToken);
        if (project == null)
        {
            throw new NotFoundException(nameof(Project), projectId);
        }

        return project;
    }
}