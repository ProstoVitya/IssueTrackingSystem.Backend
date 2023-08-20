using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueTypes.CreateIssueType;

public class CreateIssueTypeCommandHandler : IRequestHandler<CreateIssueTypeCommand>
{
    private readonly IIssueDbContext _dbContext;

    public CreateIssueTypeCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateIssueTypeCommand request, CancellationToken cancellationToken)
    {
        var type = new IssueType
        {
            Name = request.Name
        };

        _dbContext.IssueTypes.Add(type);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}