using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TODOS.Application.Common.Exceptions;
using TODOS.Application.Interfaces;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler
        : IRequestHandler<UpdateGroupCommand>
    {
        private readonly ITodosDbContext _dbContext;

        public UpdateGroupCommandHandler(ITodosDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Groups.Include(g => g.Notes).FirstOrDefaultAsync(group =>
                    group.Id == request.Id, cancellationToken);

            var notes = await _dbContext.Notes.Where(x => request.Notes.Contains(x.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            entity.Color = request.Color;
            entity.Title = request.Title;
            entity.Notes = notes;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}