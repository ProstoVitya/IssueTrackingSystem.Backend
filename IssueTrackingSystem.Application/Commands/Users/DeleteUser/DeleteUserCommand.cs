using MediatR;

namespace IssueTrackingSystem.Application.Commands.Users.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public int Id { get; }
}