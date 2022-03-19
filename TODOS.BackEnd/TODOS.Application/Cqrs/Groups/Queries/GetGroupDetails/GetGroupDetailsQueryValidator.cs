using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Groups.Queries.GetGroupDetails
{
    public class GetGroupDetailsQueryValidator : AbstractValidator<GetGroupDetailsQuery>
    {
        public GetGroupDetailsQueryValidator()
        {
            RuleFor(group => group.Id).NotEqual(Guid.Empty);
        }
    }
}