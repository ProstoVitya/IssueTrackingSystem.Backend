using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Queries.IssueStatuses.GetIssueStatusDetails;

public class GetIssueStatusDetailsQueryHandler : IRequestHandler<GetIssueStatusDetailsQuery, IssueStatus>
{
    private readonly IIssueDbContext _dbContext;

    public GetIssueStatusDetailsQueryHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IssueStatus> Handle(GetIssueStatusDetailsQuery request, CancellationToken cancellationToken)
    {
        var issueStatus = await GetIssueStatusByIdAsync(request.IssueStatusId, cancellationToken);
        return issueStatus;
    }

    private async Task<IssueStatus> GetIssueStatusByIdAsync(int issueStatusId, CancellationToken cancellationToken)
    {
        var issueStatus = await _dbContext.IssueStatuses.FirstOrDefaultAsync(status => status.Id == issueStatusId,
            cancellationToken);

        if (issueStatus == null)
        {
            throw new NotFoundException(nameof(IssueStatus), issueStatusId);
        }

        return issueStatus;
    }
}