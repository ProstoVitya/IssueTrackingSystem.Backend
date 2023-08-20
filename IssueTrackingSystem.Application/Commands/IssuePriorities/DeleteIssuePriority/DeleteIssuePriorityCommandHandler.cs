using IssueTrackingSystem.Application.Commands.Issues;
using IssueTrackingSystem.Application.Interfaces;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssuePriorities.DeleteIssuePriority;

public class DeleteIssuePriorityCommandHandler : IRequestHandler<DeleteIssuePriorityCommand>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IssueRelatedInfoDao _dao;

    public DeleteIssuePriorityCommandHandler(IIssueDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _dao = new IssueRelatedInfoDao(mediator);
    }

    public async Task Handle(DeleteIssuePriorityCommand request, CancellationToken cancellationToken)
    {
        var priority = await _dao.GetIssuePriorityByIdAsync(request.Id, cancellationToken);
        _dbContext.IssuePriorities.Remove(priority);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}