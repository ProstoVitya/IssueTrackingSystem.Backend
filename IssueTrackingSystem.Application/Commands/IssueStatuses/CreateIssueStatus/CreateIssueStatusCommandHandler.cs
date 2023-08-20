using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueStatuses.CreateIssueStatus;

public class CreateIssueStatusCommandHandler : IRequestHandler<CreateIssueStatusCommand>
{
    private readonly IIssueDbContext _dbContext;

    public CreateIssueStatusCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateIssueStatusCommand request, CancellationToken cancellationToken)
    {
        var issueStatus = new IssueStatus
        {
            Name = request.Name
        };

        _dbContext.IssueStatuses.Add(issueStatus);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}