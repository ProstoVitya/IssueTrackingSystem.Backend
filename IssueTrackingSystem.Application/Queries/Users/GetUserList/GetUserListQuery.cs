using MediatR;

namespace IssueTrackingSystem.Application.Queries.Users.GetUserList;

public class GetUserListQuery : IRequest<UserListVm>
{
    public int ProjectId { get; set; }
}