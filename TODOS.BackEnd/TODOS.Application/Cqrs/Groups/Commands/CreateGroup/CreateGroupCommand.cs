using System;
using System.Collections.Generic;
using MediatR;

namespace TODOS.Application.Cqrs.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public IList<Guid> Notes { get; set; }
    }
}