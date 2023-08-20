using IssueTrackingSystem.Domain;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.Projects.GetProject;

public class GetProjectQuery : IRequest<Project>
{
    public int ProjectId { get; set; }
}