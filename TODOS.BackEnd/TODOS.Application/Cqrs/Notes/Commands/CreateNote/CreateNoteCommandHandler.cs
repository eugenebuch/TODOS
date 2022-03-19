using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TODOS.Application.Interfaces;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler
        : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly ITodosDbContext _dbContext;

        public CreateNoteCommandHandler(ITodosDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var newId = Guid.NewGuid();
            var groups = await _dbContext.Groups.Where(x => request.Groups.Contains(x.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            var note = new Note
            {
                Title = request.Title,
                Details = request.Details,
                Deadline = request.Deadline,
                Id = newId,
                CreationDate = DateTime.Now,
                EditDate = null,
                Groups = groups,
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken); 
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}