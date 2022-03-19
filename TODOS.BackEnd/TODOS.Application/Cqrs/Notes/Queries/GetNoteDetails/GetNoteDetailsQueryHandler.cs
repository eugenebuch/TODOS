using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TODOS.Application.Common.Exceptions;
using TODOS.Application.Interfaces;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler
        : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly ITodosDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(ITodosDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.Include(n => n.Groups)
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}