using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Users.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEqual(Guid.Empty);
    }
}