using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Issues.CreateIssue;

public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IMediator _mediator;

    public CreateIssueCommandHandler(IIssueDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    public async Task Handle(CreateIssueCommand request, CancellationToken cancellationToken)
    {
        var issueDao = new IssueRelatedInfoDao(_mediator);
        var assignee = await issueDao.GetUserByIdAsync(request.AssigneeId, cancellationToken);
        var author = await issueDao.GetUserByIdAsync(request.AssigneeId, cancellationToken);
        var issueType = await issueDao.GetIssueTypeByIdAsync(request.IssueTypeId, cancellationToken);
        var issuePriority = await issueDao.GetIssuePriorityByIdAsync(request.PriorityId, cancellationToken);
        var status = await issueDao.GetIssueStatusByIdAsync(request.IssueTypeId, cancellationToken);
        var project = await issueDao.GetIssueProjectByIdAsync(request.IssueTypeId, cancellationToken);
        var issueIndex = await issueDao.GetProjectIssueIndexByProjectIdAsync(project.Id, cancellationToken);

        var issue = new Issue
        {
            Index = issueIndex.Index,
            Name = request.Name,
            ProjectId = project.Id,
            Description = request.Description,
            StoryPoints = request.StoryPoints,
            Created = DateTime.Now,
            LastModified = DateTime.Now,
            Started = request.Started,
            FixBefore = request.FixBefore,
            Assignee = assignee,
            Type = issueType,
            Priority = issuePriority,
            Status = status,
            Project = project,
            Author = author,
        };

        _dbContext.Issues.Add(issue);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}