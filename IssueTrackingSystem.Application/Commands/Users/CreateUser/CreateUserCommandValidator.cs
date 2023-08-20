using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Users.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
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