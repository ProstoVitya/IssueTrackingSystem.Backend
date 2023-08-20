using AutoMapper;
using AutoMapper.QueryableExtensions;
using IssueTrackingSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Queries.Users.GetUserList;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public GetUserListQueryHandler(IIssueDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await GetUsersAsync(request.ProjectId, cancellationToken);
        return new UserListVm { Users = users };
    }

    private async Task<List<UserLookupDto>> GetUsersAsync(int projectId, CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users.Where(u =>
                u.RelatedProjects.Any(proj =>proj.Id == projectId))
            .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return users;
    }
}