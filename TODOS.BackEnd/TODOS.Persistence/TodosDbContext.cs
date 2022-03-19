using Microsoft.EntityFrameworkCore;
using TODOS.Application.Interfaces;
using TODOS.Domain;
using TODOS.Persistence.EntityTypeConfiguration;

namespace TODOS.Persistence
{
    public class TodosDbContext : DbContext, ITodosDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Group> Groups { get; set; }

        public TodosDbContext(DbContextOptions<TodosDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}