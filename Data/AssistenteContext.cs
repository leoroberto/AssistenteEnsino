using AssistenteDeEnsino.Components.Player;
using Microsoft.EntityFrameworkCore;

namespace AssistenteDeEnsino.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Video> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the Video entity
        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnType("CHAR(36)") // Armazena o GUID como string formatada
                .IsRequired();
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Url).IsRequired();
            entity.Property(e => e.Slug).IsRequired();
            entity.Property(e => e.Transcript).IsRequired();
        });
    }
}