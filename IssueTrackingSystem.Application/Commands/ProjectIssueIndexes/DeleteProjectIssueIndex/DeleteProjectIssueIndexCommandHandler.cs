using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.DeleteProjectIssueIndex;

public class DeleteProjectIssueIndexCommandHandler : IRequestHandler<DeleteProjectIssueIndexCommand>
{
    private readonly IIssueDbContext _dbContext;

    public DeleteProjectIssueIndexCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteProjectIssueIndexCommand request, CancellationToken cancellationToken)
    {
        var indexes = GetProjectIssueIndex(request.ProjectId);
        if (!indexes.Any())
        {
            return;
        }

        _dbContext.ProjectIssueIndexes.RemoveRange(indexes);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    private IEnumerable<ProjectIssueIndex> GetProjectIssueIndex(int projectId)
    {
        var index = _dbContext.ProjectIssueIndexes.Where(i => i.Project.Id == projectId)
            .ToList();

        return index;
    }
}