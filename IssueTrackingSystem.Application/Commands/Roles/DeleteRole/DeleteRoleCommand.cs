using MediatR;

namespace IssueTrackingSystem.Application.Commands.Roles.DeleteRole;

public class DeleteRoleCommand : IRequest
{
    public int Id { get; set; }
}