using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Queries.IssuePriorities.GetIssuePriorityDetails;

public class GetIssuePriorityDetailsQueryHandler : IRequestHandler<GetIssuePriorityDetailsQuery, IssuePriority>
{
    private readonly IIssueDbContext _dbContext;

    public GetIssuePriorityDetailsQueryHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IssuePriority> Handle(GetIssuePriorityDetailsQuery request, CancellationToken cancellationToken)
    {
        var priority = await GetIssuePriorityByIdAsync(request.IssuePriorityId, cancellationToken);
        return priority;
    }

    private async Task<IssuePriority> GetIssuePriorityByIdAsync(int priorityId, CancellationToken cancellationToken)
    {
        var priority = await _dbContext.IssuePriorities.FirstOrDefaultAsync(p => p.Id == priorityId,
            cancellationToken);
        if (priority == null)
        {
            throw new NotFoundException(nameof(IssuePriority), priorityId);
        }

        return priority;
    }
}