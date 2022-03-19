using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.Title).NotEmpty().MaximumLength(100);
            RuleFor(updateNoteCommand => updateNoteCommand.Details).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand => createNoteCommand.Deadline)
                .NotNull().GreaterThan(DateTime.Now);
        }
    }
}