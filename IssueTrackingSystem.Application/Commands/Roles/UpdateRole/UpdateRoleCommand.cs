using MediatR;

namespace IssueTrackingSystem.Application.Commands.Roles.UpdateRole;

public class UpdateRoleCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}