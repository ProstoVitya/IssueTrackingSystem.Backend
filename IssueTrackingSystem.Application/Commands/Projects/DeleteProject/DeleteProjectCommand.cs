using MediatR;

namespace IssueTrackingSystem.Application.Commands.Projects.DeleteProject;

public class DeleteProjectCommand : IRequest
{
    public int Id { get; }
}