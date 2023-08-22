using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Roles.DeleteRole;

public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);
    }
}