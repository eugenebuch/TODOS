using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TODOS.Application.Interfaces;

namespace TODOS.Application.Cqrs.Groups.Queries.GetGroupList
{
    public class GetGroupListQueryHandler
        : IRequestHandler<GetGroupListQuery, GroupListVm>
    {
        private readonly ITodosDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGroupListQueryHandler(ITodosDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GroupListVm> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
        {
            var groupsQuery = await _dbContext.Groups
                .ProjectTo<GroupLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GroupListVm { Groups = groupsQuery };
        }
    }
}