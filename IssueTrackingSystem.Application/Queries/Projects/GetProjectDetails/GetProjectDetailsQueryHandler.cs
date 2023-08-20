using AutoMapper;
using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Queries.Projects.GetProjectDetails;

public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsDto>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProjectDetailsQueryHandler(IIssueDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ProjectDetailsDto> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
    {
        var project = await GetProjectAsync(request.ProjectId, cancellationToken);
        var projectDetails = _mapper.Map<Project, ProjectDetailsDto>(project);
        return projectDetails;
    }

    private async Task<Project> GetProjectAsync(int projectId, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(proj =>
            proj.Id == projectId, cancellationToken);
        if (project == null)
        {
            throw new NotFoundException(nameof(Project), projectId);
        }

        return project;
    }
}