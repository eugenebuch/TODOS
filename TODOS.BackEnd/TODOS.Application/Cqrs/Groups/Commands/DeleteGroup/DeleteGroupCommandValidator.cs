using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
    {
        public DeleteGroupCommandValidator()
        {
            RuleFor(deleteGroupCommand => deleteGroupCommand.Id).NotEqual(Guid.Empty);
        }
    }
}