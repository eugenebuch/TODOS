using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
        }       
    }
}