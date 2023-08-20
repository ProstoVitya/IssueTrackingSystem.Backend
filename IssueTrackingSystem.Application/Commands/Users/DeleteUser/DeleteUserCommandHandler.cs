using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Users;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Users.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IIssueDbContext _dbContext;

    public DeleteUserCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await GetUser(request.Id, cancellationToken);
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<User> GetUser(int userId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(new object[] { userId }, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), userId);
        }

        return user;
    }
}