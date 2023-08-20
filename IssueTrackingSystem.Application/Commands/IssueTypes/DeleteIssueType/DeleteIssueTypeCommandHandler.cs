using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueTypes.DeleteIssueType;

public class DeleteIssueTypeCommandHandler : IRequestHandler<DeleteIssueTypeCommand>
{
    private readonly IIssueDbContext _dbContext;

    public DeleteIssueTypeCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteIssueTypeCommand request, CancellationToken cancellationToken)
    {
        var type = GetIssueType(request.Id);
        _dbContext.IssueTypes.Remove(type);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    private IssueType GetIssueType(int typeId)
    {
        var type = _dbContext.IssueTypes.FirstOrDefault(type => type.Id == typeId);
        if (type == null)
        {
            throw new NotFoundException(nameof(IssueType), typeId);
        }

        return type;
    }
}