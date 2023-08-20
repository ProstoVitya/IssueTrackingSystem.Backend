using IssueTrackingSystem.Application.Commands.Issues;
using IssueTrackingSystem.Application.Interfaces;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueStatuses.UpdateIssueStatus;

public class UpdateIssueStatusCommandHandler : IRequestHandler<UpdateIssueStatusCommand>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IssueRelatedInfoDao _dao;
    
    public UpdateIssueStatusCommandHandler(IMediator mediator, IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
        _dao = new IssueRelatedInfoDao(mediator);
    }

    public async Task Handle(UpdateIssueStatusCommand request, CancellationToken cancellationToken)
    {
        var issueStatus = await _dao.GetIssueStatusByIdAsync(request.Id, cancellationToken);
        issueStatus.Name = request.Name;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}