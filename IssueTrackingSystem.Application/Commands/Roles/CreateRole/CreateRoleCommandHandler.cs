using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Users;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Roles.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
{
    private readonly IIssueDbContext _dbContext;

    public CreateRoleCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            Name = request.Name
        };

        _dbContext.Roles.Add(role);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}