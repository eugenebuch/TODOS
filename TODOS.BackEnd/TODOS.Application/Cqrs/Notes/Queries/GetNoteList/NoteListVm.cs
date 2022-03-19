using System.Collections.Generic;

namespace TODOS.Application.Cqrs.Notes.Queries.GetNoteList
{
    public class NoteListVm
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}