using System;
using MediatR;

namespace TODOS.Application.Cqrs.Notes.Queries.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListVm> 
    {
    }
}