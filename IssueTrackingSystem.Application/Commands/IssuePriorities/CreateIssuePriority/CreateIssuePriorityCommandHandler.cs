using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssuePriorities.CreateIssuePriority;

public class CreateIssuePriorityCommandHandler : IRequestHandler<CreateIssuePriorityCommand>
{
    private readonly IIssueDbContext _dbContext;

    public CreateIssuePriorityCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateIssuePriorityCommand request, CancellationToken cancellationToken)
    {
        var issuePriority = new IssuePriority
        {
            Name = request.Name
        };

        await _dbContext.IssuePriorities.AddAsync(issuePriority, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}