using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TODOS.Application.Interfaces;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler
        : IRequestHandler<CreateGroupCommand, Guid>
    {
        private readonly ITodosDbContext _dbContext;

        public CreateGroupCommandHandler(ITodosDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var newId = Guid.NewGuid();

            var notes = await _dbContext.Notes.Where(x => request.Notes.Contains(x.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            var group = new Group
            {
                Title = request.Title,
                Color = request.Color,
                Id = newId,
                Notes = notes,
            };

            await _dbContext.Groups.AddAsync(group, cancellationToken); 
            await _dbContext.SaveChangesAsync(cancellationToken);

            return group.Id;
        }
    }
}