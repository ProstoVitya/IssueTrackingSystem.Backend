using AutoMapper;
using AutoMapper.QueryableExtensions;
using IssueTrackingSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Queries.Issues.GetIssueList;

public class GetIssueListQueryHandler : IRequestHandler<GetIssueListQuery, IssueListVm>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetIssueListQueryHandler(IIssueDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IssueListVm> Handle(GetIssueListQuery request, CancellationToken cancellationToken)
    {
        List<IssueLookupDto> issues;
        if (request.ProjectId != 0)
        {
            //TODO: как сделать запросы по разным параметрам НОРАМАЛЬНО
            issues = await _dbContext.Issues.Where(issue => issue.Project.Id == request.ProjectId)
                .ProjectTo<IssueLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
        else
        {
            issues = await _dbContext.Issues.Where(issue => issue.Assignee.Id == request.AssigneeId)
                .ProjectTo<IssueLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        return new IssueListVm { Issues = issues };
    }
}