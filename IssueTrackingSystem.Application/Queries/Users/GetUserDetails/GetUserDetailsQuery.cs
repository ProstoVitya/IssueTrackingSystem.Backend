using IssueTrackingSystem.Domain.Users;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.Users.GetUserDetails;

public class GetUserDetailsQuery : IRequest<User>
{
    public Guid UserId { get; set; }
}