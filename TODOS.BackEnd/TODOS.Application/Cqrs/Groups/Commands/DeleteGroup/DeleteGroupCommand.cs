using System;
using MediatR;

namespace TODOS.Application.Cqrs.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}