using System;
using MediatR;

namespace TODOS.Application.Cqrs.Groups.Queries.GetGroupDetails
{
    public class GetGroupDetailsQuery : IRequest<GroupDetailsVm>
    {
        public Guid Id { get; set; }
    }
}