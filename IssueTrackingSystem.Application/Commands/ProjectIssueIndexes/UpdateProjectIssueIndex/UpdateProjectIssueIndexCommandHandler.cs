using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.UpdateProjectIssueIndex;

public class UpdateProjectIssueIndexCommandHandler : IRequestHandler<UpdateProjectIssueIndexCommand>
{
    private readonly IIssueDbContext _dbContext;

    public UpdateProjectIssueIndexCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateProjectIssueIndexCommand request, CancellationToken cancellationToken)
    {
        var index = GetProjectIssueIndex(request.ProjectId);
        ++index.Index;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private ProjectIssueIndex GetProjectIssueIndex(int projectId)
    {
        var index = _dbContext.ProjectIssueIndexes.FirstOrDefault(i => i.Project.Id == projectId);
        if (index == null)
        {
            throw new NotFoundException(nameof(ProjectIssueIndex), projectId);
        }

        return index;
    }
}