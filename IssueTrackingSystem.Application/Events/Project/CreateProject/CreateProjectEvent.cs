using MediatR;

namespace IssueTrackingSystem.Application.Events.Project.CreateProject;

public class CreateProjectEvent : INotification
{
    public int ProjectId { get; set; }
}