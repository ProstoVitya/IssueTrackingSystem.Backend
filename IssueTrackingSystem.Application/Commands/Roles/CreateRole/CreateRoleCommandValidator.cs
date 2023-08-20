using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Roles.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(createRoleCommand => createRoleCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }
}