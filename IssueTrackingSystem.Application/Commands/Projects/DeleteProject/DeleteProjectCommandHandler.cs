using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Commands.Projects.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IIssueDbContext _dbContext;

    public DeleteProjectCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await GetProjectAsync(request.Id, cancellationToken);
        _dbContext.Projects.Remove(project);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<Project> GetProjectAsync(int projectId, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(proj =>
            proj.Id == projectId, cancellationToken);
        if (project == null)
        {
            throw new NotFoundException(nameof(Project), projectId);
        }

        return project;
    }
}