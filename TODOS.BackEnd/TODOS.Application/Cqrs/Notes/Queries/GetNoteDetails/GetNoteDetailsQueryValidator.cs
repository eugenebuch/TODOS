using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
    {
        public GetNoteDetailsQueryValidator()
        {
            RuleFor(note => note.Id).NotEqual(Guid.Empty);
        }
    }
}