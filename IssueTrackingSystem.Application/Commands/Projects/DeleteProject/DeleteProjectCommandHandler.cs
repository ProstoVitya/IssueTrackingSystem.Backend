using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Events.Project.DeleteProject;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Commands.Projects.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IMediator _mediator;

    public DeleteProjectCommandHandler(IIssueDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await GetProjectAsync(request.Id, cancellationToken);
        _dbContext.Projects.Remove(project);
        await _dbContext.SaveChangesAsync(cancellationToken);
        await _dbContext.Entry(project).ReloadAsync(cancellationToken);
        
        await SendOnProjectDeleteNotification(project.Id);
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
    
    private async Task SendOnProjectDeleteNotification(int projectId)
    {
        var createProjectEvent = new DeleteProjectEvent
        {
            ProjectId = projectId
        };
        await _mediator.Send(createProjectEvent);
    }
}