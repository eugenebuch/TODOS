using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(createGroupCommand =>
                createGroupCommand.Title).NotEmpty().MaximumLength(100);
        }
    }
}