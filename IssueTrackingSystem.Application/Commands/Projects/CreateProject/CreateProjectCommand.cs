using IssueTrackingSystem.Domain.Users;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Projects.CreateProject;

public class CreateProjectCommand : IRequest
{
    public string Name { get; }
    public string Description { get; }
    public ISet<User> Collaborators { get; } 
}