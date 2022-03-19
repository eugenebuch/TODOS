using System;
using System.Collections.Generic;
using MediatR;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Deadline { get; set; }
        public IList<Guid> Groups { get; set; }
    }
}