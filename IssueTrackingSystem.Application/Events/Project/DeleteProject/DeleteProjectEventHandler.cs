using IssueTrackingSystem.Application.Commands.Issues.DeleteAllProjectIssues;
using IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.DeleteProjectIssueIndex;
using MediatR;

namespace IssueTrackingSystem.Application.Events.Project.DeleteProject;

public class DeleteProjectEventHandler : INotificationHandler<DeleteProjectEvent>
{
    private readonly IMediator _mediator;

    public DeleteProjectEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(DeleteProjectEvent notification, CancellationToken cancellationToken)
    {
        await DeleteProjectIssues(notification.ProjectId, cancellationToken);
        await DeleteProjectIssueIndexes(notification.ProjectId, cancellationToken);
    }

    private async Task DeleteProjectIssues(int projectId, CancellationToken cancellationToken)
    {
        var deleteProjectIssues = new DeleteAllProjectIssuesCommand
        {
            ProjectId = projectId
        };
        await _mediator.Send(deleteProjectIssues, cancellationToken);
    }
    
    private async Task  DeleteProjectIssueIndexes(int projectId, CancellationToken cancellationToken)
    {
        var deleteProjectIssueIndex = new DeleteProjectIssueIndexCommand
        {
            ProjectId = projectId
        };
        await _mediator.Send(deleteProjectIssueIndex, cancellationToken);
    }
}