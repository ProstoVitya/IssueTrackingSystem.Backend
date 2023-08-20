using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Commands.Projects.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IIssueDbContext _dbContext;

    public UpdateProjectCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await GetProjectAsync(request.Id, cancellationToken);
        UpdateProject(project, request);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<Project> GetProjectAsync(int projectId, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(proj => proj.Id == projectId);
        if (project == null)
        {
            throw new NotFoundException(nameof(project), projectId);
        }

        return project;
    }

    private void UpdateProject(Project project, UpdateProjectCommand request)
    {
        project.Name = request.Name;
        project.Description = request.Description;
        project.Collaborators = request.Collaborators;
        project.Issues = request.Issues;
    }
}