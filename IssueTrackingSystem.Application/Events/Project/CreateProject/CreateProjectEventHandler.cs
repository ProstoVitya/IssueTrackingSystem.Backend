using IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.CreateProjectIssueIndex;
using MediatR;

namespace IssueTrackingSystem.Application.Events.Project.CreateProject;

public class CreateProjectEventHandler : INotificationHandler<CreateProjectEvent>
{
    private readonly IMediator _mediator;

    public CreateProjectEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(CreateProjectEvent notification, CancellationToken cancellationToken)
    {
        var createProjectIssueIndex = new CreateProjectIssueIndexCommand
        {
            ProjectId = notification.ProjectId
        };

        await _mediator.Send(createProjectIssueIndex, cancellationToken);
    }
}