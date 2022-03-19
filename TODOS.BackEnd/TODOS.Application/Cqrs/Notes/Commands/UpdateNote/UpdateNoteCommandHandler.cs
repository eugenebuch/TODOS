using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TODOS.Application.Common.Exceptions;
using TODOS.Application.Interfaces;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler 
        : IRequestHandler<UpdateNoteCommand>
    {
        private readonly ITodosDbContext _dbContext;

        public UpdateNoteCommandHandler(ITodosDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notes.Include(n => n.Groups).FirstOrDefaultAsync(note => 
                    note.Id == request.Id, cancellationToken);

            var groups = await _dbContext.Groups.Where(x => request.Groups.Contains(x.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;
            entity.Deadline = request.Deadline;
            entity.Groups = groups;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}