using IssueTrackingSystem.Application.Commands.Issues;
using IssueTrackingSystem.Application.Interfaces;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueStatuses.DeleteIssueStatus;

public class DeleteIssueStatusCommandHandler : IRequestHandler<DeleteIssueStatusCommand>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IssueRelatedInfoDao _dao;
    
    public DeleteIssueStatusCommandHandler(IIssueDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _dao = new IssueRelatedInfoDao(mediator);
    }

    public async Task Handle(DeleteIssueStatusCommand request, CancellationToken cancellationToken)
    {
        var issueStatus = await _dao.GetIssueStatusByIdAsync(request.Id, cancellationToken);
        _dbContext.IssueStatuses.Remove(issueStatus);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}