using IssueTrackingSystem.Domain;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.Projects.GetProjectDetails;

public class GetProjectDetailsQuery : IRequest<ProjectDetailsDto>
{
    public int ProjectId { get; set; }
}