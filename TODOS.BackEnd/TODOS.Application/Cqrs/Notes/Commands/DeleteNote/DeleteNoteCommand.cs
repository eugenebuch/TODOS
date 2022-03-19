using System;
using MediatR;

namespace TODOS.Application.Cqrs.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}