using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TODOS.Application.Common.Exceptions;
using TODOS.Application.Interfaces;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler :
        IRequestHandler<DeleteNoteCommand>
    {
        private readonly ITodosDbContext _dbContext;

        public DeleteNoteCommandHandler(ITodosDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}