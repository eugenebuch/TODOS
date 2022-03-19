using System;
using System.Collections.Generic;
using MediatR;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Deadline { get; set; }
        public IList<Guid> Groups { get; set; }
    }
}