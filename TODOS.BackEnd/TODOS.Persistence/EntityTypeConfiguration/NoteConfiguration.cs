using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TODOS.Domain;

namespace TODOS.Persistence.EntityTypeConfiguration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Title).HasMaxLength(250);
            builder
                .HasMany(n => n.Groups)
                .WithMany(g => g.Notes)
                .UsingEntity(j => j.ToTable("NoteGroups"));
        }
    }
}