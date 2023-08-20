using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Commands.Issues.DeleteIssue;

public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand>
{
    private readonly IIssueDbContext _issueDbContext;

    public DeleteIssueCommandHandler(IIssueDbContext issueDbContext)
    {
        _issueDbContext = issueDbContext;
    }

    public async Task Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = await GetIssueAsync(request, cancellationToken);
        _issueDbContext.Issues.Remove(issue);
        await _issueDbContext.SaveChangesAsync(cancellationToken);
    }
    
    private async Task<Issue> GetIssueAsync(DeleteIssueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _issueDbContext.Issues.FirstOrDefaultAsync(issue =>
            new { ProjectId = issue.ProjectKey, Index = issue.Id } == new { request.ProjectId, Index = request.IssueIndex },
            cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Issue), new { Index = request.IssueIndex, request.ProjectId });
        }

        return entity;
    }
}