using IssueTrackingSystem.Application.Commands.Issues;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.CreateProjectIssueIndex;

public class CreateProjectIssueIndexCommandHandler : IRequestHandler<CreateProjectIssueIndexCommand>
{
    private readonly IIssueDbContext _dbContext;
    private readonly IssueRelatedInfoDao _dao;

    public CreateProjectIssueIndexCommandHandler(IMediator mediator, IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
        _dao = new IssueRelatedInfoDao(mediator);
    }
    
    public async Task Handle(CreateProjectIssueIndexCommand request, CancellationToken cancellationToken)
    {
        var project = await _dao.GetIssueProjectByIdAsync(request.ProjectId, cancellationToken);

        var projectIssueIndex = new ProjectIssueIndex
        {
            Project = project,
            Index = 1
        };

        _dbContext.ProjectIssueIndexes.Add(projectIssueIndex);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}