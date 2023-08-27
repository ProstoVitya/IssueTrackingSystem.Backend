using MediatR;

namespace IssueTrackingSystem.Application.Events.Project.DeleteProject;

public class DeleteProjectEvent : INotification
{
    public int ProjectId { get; set; }
}