using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TODOS.Application.Common.Exceptions;
using TODOS.Application.Interfaces;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandHandler :
        IRequestHandler<DeleteGroupCommand>
    {
        private readonly ITodosDbContext _dbContext;

        public DeleteGroupCommandHandler(ITodosDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Groups
                .FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            _dbContext.Groups.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}