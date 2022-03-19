using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TODOS.Application.Interfaces;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler
        : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly ITodosDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(ITodosDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Notes
                .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NoteListVm {Notes = notesQuery};
        }
    }
}