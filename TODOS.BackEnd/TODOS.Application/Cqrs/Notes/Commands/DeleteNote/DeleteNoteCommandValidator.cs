using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(deleteNoteCommand => deleteNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}