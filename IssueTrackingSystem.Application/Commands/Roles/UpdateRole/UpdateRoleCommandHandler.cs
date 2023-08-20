using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Users;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Roles.UpdateRole;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly IIssueDbContext _dbContext;

    public UpdateRoleCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = GetRole(request.Id);
        role.Name = request.Name;
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