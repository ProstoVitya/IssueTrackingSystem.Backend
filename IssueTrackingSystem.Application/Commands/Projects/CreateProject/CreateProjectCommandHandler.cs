using IssueTrackingSystem.Application.Events.Project.CreateProject;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Projects.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IMediator _mediator;
    public CreateProjectCommandHandler(IIssueDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            Name = request.Name,
            Description = request.Description,
            Collaborators = request.Collaborators
        };
        
        _dbContext.Projects.Add(project);
        
        await  _dbContext.SaveChangesAsync(cancellationToken);
        await _dbContext.Entry(project).ReloadAsync(cancellationToken);
        
        await SendOnProjectCreateNotification(project.Id);
    }

    private async Task SendOnProjectCreateNotification(int projectId)
    {
        var createProjectEvent = new CreateProjectEvent
        {
            ProjectId = projectId
        };
        await _mediator.Send(createProjectEvent);
    }
}