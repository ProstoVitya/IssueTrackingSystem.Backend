using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Users;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IIssueDbContext _dbContext;

    public CreateUserCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Login = request.Login,
            Email = request.Email,
            Password = request.Password,
            Role = request.Role,
            RegistrationDate = DateTime.Now,
            Rights = request.Rights,
            RelatedProjects = request.RelatedProjects
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}