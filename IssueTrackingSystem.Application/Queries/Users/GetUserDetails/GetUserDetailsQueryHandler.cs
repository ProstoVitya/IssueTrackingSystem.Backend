using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Queries.Users.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, User>
{
    private readonly IIssueDbContext _dbContext;

    public GetUserDetailsQueryHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await GetUserAsync(request.UserId, cancellationToken);
        return user;
    }

    private async Task<User> GetUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException(nameof(user), userId);
        }

        return user;
    }
}