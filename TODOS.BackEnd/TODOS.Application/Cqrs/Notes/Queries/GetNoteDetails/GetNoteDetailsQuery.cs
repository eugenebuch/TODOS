using System;
using MediatR;

namespace TODOS.Application.Cqrs.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQuery : IRequest<NoteDetailsVm>
    {
        public Guid Id { get; set; }
    }
}