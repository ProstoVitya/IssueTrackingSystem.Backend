﻿using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Roles.UpdateRole;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(updateRoleCommand => updateRoleCommand.Id)
            .GreaterThan(0);
        RuleFor(updateRoleCommand => updateRoleCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }
}