using IssueTrackingSystem.Application.Commands.Issues;
using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssuePriorities.UpdateIssuePriority;

public class UpdateIssuePriorityCommandHandler : IRequestHandler<UpdateIssuePriorityCommand>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IssueRelatedInfoDao _dao;

    public UpdateIssuePriorityCommandHandler(IIssueDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _dao = new IssueRelatedInfoDao(mediator);
    }

    public async Task Handle(UpdateIssuePriorityCommand request, CancellationToken cancellationToken)
    {
        var issuePriority = await _dao.GetIssuePriorityByIdAsync(request.Id, cancellationToken);
        issuePriority.Name = request.Name;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}