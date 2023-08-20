using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IssueTrackingSystem.Application.Commands.Issues.UpdateIssue;

public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IMediator _mediator;

    public UpdateIssueCommandHandler(IIssueDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    public async Task Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = await GetIssueAsync(request, cancellationToken);
        await UpdateIssue(issue, request, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task UpdateIssue(Issue issue, UpdateIssueCommand request, CancellationToken cancellationToken)
    {
        var issueDao = new IssueRelatedInfoDao(_mediator);
        var assignee = await issueDao.GetUserByIdAsync(request.AssigneeId, cancellationToken);
        var issueType = await issueDao.GetIssueTypeByIdAsync(request.IssueTypeId, cancellationToken);
        var issuePriority = await issueDao.GetIssuePriorityByIdAsync(request.PriorityId, cancellationToken);
        var issueStatus = await issueDao.GetIssueStatusByIdAsync(request.StatusId, cancellationToken);
        
        issue.Name = request.Name;
        issue.Description = request.Description;
        issue.StoryPoints = request.StoryPoints;
        issue.DevelopCommit = request.DevelopCommit;
        issue.ReleaseCommit = request.ReleaseCommit;
        issue.LastModified = DateTime.Now;
        issue.Started = request.Started;
        issue.Finished = request.Finished;
        issue.Finished = request.FixBefore;
        issue.Assignee = assignee;
        issue.Type = issueType;
        issue.Priority = issuePriority;
        issue.Status = issueStatus;
    }

    private async Task<Issue> GetIssueAsync(UpdateIssueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Issues.FirstOrDefaultAsync(issue =>
            new { IssueIndex = issue.Id, ProjectId = issue.ProjectKey } == new { request.IssueIndex, request.ProjectId },
            cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Issue), new { Index = request.IssueIndex, request.ProjectId });
        }

        return entity;
    }
}