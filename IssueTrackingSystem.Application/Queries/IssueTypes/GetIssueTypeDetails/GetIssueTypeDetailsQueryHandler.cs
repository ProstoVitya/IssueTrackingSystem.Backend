using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.IssueTypes.GetIssueTypeDetails;

public class GetIssueTypeDetailsQueryHandler : IRequestHandler<GetIssueTypeDetailsQuery, IssueType>
{
    private readonly IIssueDbContext _dbContext;

    public GetIssueTypeDetailsQueryHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IssueType> Handle(GetIssueTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var issueType = GetIssueType(request.IssueTypeId);
        return Task.FromResult(issueType);
    }

    private IssueType GetIssueType(int typeId)
    {
        var issueType = _dbContext.IssueTypes.FirstOrDefault(type => type.Id == typeId);
        if (issueType == null)
        {
            throw new NotFoundException(nameof(IssueType), typeId);
        }

        return issueType;
    }
}