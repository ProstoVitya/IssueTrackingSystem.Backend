using IssueTrackingSystem.Domain;
using IssueTrackingSystem.Domain.Users;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Users.CreateUser;

public class CreateUserCommand : IRequest
{
    public string Name { get; }
    public string Login { get; }
    public string Email { get; }
    public string Password { get; }
    public Role Role { get; }
    public ISet<Rights> Rights { get; }
    public ISet<Project> RelatedProjects { get; }
}