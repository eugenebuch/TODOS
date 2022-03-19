using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
        {
            RuleFor(updateGroupCommand => updateGroupCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateGroupCommand => updateGroupCommand.Title).NotEmpty().MaximumLength(100);
        }
    }
}