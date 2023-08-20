using IssueTrackingSystem.Application.Common.Exceptions;
using IssueTrackingSystem.Application.Interfaces;
using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueTypes.UpdateIssueType;

public class UpdateIssueTypeCommandHandler : IRequestHandler<UpdateIssueTypeCommand>
{
    private readonly IIssueDbContext _dbContext;

    public UpdateIssueTypeCommandHandler(IIssueDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task Handle(UpdateIssueTypeCommand request, CancellationToken cancellationToken)
    {
        var type = GetIssueType(request.Id);
        type.Name = request.Name;
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