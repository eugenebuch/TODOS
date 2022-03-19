using System;
using FluentValidation;

namespace TODOS.Application.Cqrs.Groups.Queries.GetGroupList
{
    public class GetGroupListQueryValidator : AbstractValidator<GetGroupListQuery>
    {
        public GetGroupListQueryValidator()
        {
        }       
    }
}