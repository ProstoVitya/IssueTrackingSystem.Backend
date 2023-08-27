using MediatR;

namespace IssueTrackingSystem.Application.Events.Issue.CreateIssue;

public class CreateIssueEvent : INotification
{
    public int ProjectId { get; set; }
}