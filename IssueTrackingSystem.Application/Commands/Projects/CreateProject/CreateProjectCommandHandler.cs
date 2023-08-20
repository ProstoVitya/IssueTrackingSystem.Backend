using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Projects.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
{
    private readonly IIssueDbContext _dbContext;

    public CreateProjectCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            Name = request.Name,
            Description = request.Description,
            Collaborators = request.Collaborators
        };
        
        _dbContext.Projects.Add(project);
        await  _dbContext.SaveChangesAsync(cancellationToken);
    }
}