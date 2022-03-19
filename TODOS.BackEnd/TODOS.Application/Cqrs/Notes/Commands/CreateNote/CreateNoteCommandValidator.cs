using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand =>
                createNoteCommand.Title).NotEmpty().MaximumLength(100);
            RuleFor(createNoteCommand =>
                createNoteCommand.Details).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand => createNoteCommand.Deadline)
                .NotNull().GreaterThan(DateTime.Now);
        }
    }
}