using MediatR;

namespace IssueTrackingSystem.Application.Commands.Roles.CreateRole;

public class CreateRoleCommand : IRequest
{
    public string Name { get; set; }
}