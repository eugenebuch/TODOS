using System;
using System.Collections.Generic;
using MediatR;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public IList<Guid> Notes { get; set; }
    }
}