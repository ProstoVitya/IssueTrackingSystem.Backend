using IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.UpdateProjectIssueIndex;
using MediatR;

namespace IssueTrackingSystem.Application.Events.Issue.CreateIssue;

public class CreateIssueEventHandler : INotificationHandler<CreateIssueEvent>
{
    private readonly IMediator _mediator;
    
    public CreateIssueEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(CreateIssueEvent notification, CancellationToken cancellationToken)
    {
        await UpdateProjectIssueIndex(notification.ProjectId, cancellationToken);
    }

    private async Task UpdateProjectIssueIndex(int projectId, CancellationToken cancellationToken)
    {
        var updateProjectIssueIndex = new UpdateProjectIssueIndexCommand
        {
            ProjectId = projectId
        };
        await _mediator.Send(updateProjectIssueIndex, cancellationToken);
    }
}