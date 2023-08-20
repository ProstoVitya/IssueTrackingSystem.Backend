using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Users.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(updateUserCommand => updateUserCommand.Id)
            .NotEqual(Guid.Empty);
        RuleFor(createUserCommand => createUserCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
        RuleFor(createUserCommand => createUserCommand.Login)
            .NotNull()
            .NotEqual(string.Empty);
        RuleFor(createUserCommand => createUserCommand.Email)
            .NotNull()
            .NotEqual(string.Empty);
        RuleFor(createUserCommand => createUserCommand.Password)
            .NotNull()
            .NotEqual(string.Empty);
        RuleFor(createUserCommand => createUserCommand.Role)
            .NotNull();
    }
}