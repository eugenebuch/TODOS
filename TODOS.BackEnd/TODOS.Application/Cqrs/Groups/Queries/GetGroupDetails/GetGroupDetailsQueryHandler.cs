using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TODOS.Application.Common.Exceptions;
using TODOS.Application.Interfaces;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Groups.Queries.GetGroupDetails
{
    public class GetGroupDetailsQueryHandler
        : IRequestHandler<GetGroupDetailsQuery, GroupDetailsVm>
    {
        private readonly ITodosDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGroupDetailsQueryHandler(ITodosDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GroupDetailsVm> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Groups.Include(g => g.Notes)
                .FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            return _mapper.Map<GroupDetailsVm>(entity);
        }
    }
}