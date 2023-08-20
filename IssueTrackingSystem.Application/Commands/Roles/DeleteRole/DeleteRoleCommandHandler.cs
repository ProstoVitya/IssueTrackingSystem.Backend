using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Users;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Roles.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly IIssueDbContext _dbContext;
    
    public DeleteRoleCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = GetRole(request.Id);
        _dbContext.Roles.Remove(role);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private Role GetRole(int id)
    {
        var role = _dbContext.Roles.FirstOrDefault(r => r.Id == id);
        if (role == null)
        {
            throw new NotFoundException(nameof(Role), id);
        }

        return role;
    }
}