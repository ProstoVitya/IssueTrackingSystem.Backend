using FluentValidation;

namespace IssueTrackingSystem.Application.Commands.Projects.UpdateProject;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(updateProjectCommand => updateProjectCommand.Id)
            .GreaterThan(0);
        RuleFor(updateProjectCommand => updateProjectCommand.Name)
            .NotNull()
            .NotEqual(string.Empty);
    }    
}