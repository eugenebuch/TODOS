using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOS.Domain;

namespace TODOS.Application.Interfaces
{
    public interface ITodosDbContext
    {
        DbSet<Note> Notes { get; }
        DbSet<Group> Groups { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}