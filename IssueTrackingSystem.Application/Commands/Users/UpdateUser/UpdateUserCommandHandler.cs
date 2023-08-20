using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Commands.Users.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IIssueDbContext _dbContext;

    public UpdateUserCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await GetUserAsync(request.Id, cancellationToken);
        UpdateUser(user, request);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<User> GetUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), userId);
        }

        return user;
    }
    
    private static void UpdateUser(User user, UpdateUserCommand request)
    {
        user.Name = request.Name;
        user.Login = request.Login;
        user.Password = request.Password;
        user.Email = request.Email;
        user.Role = request.Role;
        user.Rights = request.Rights;
        user.RelatedProjects = request.RelatedProjects;
    }
}