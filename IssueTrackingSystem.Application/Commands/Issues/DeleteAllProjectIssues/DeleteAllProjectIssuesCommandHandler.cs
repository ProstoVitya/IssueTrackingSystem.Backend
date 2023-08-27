using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Issues.DeleteAllProjectIssues;

public class DeleteAllProjectIssuesCommandHandler : IRequestHandler<DeleteAllProjectIssuesCommand>
{
    private readonly IIssueDbContext _dbContext;

    public DeleteAllProjectIssuesCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteAllProjectIssuesCommand request, CancellationToken cancellationToken)
    {
        var issues = GetAllProjectIssues(request.ProjectId);
        if(!issues.Any())
        {
            return;
        }

        _dbContext.Issues.RemoveRange(issues);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private IEnumerable<Issue> GetAllProjectIssues(int projectId)
    {
        var issues = _dbContext.Issues.Where(i => i.ProjectId == projectId)
            .ToList();

        return issues;
    }
}