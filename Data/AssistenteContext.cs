using AssistenteDeEnsino.Components.Interview.Entities;
using AssistenteDeEnsino.Components.Player;
using Microsoft.EntityFrameworkCore;

namespace AssistenteDeEnsino.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Video> Videos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Nota> Notas { get; set; } // Adiciona o DbSet para a entidade Nota

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

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            // Configurar o Id como auto incremento
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd(); // Informa ao EF Core que o valor será gerado pelo banco de dados
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
        });
        
        // Configure a entidade Nota
        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.Id);  // Define a chave primária como int
            entity.Property(e => e.Id).ValueGeneratedOnAdd();  // Auto incremento para a chave primária
            entity.Property(e => e.UserId).IsRequired(); // Define que a chave estrangeira é obrigatória

            // Relacionamento de 1:1 entre Nota e User
            entity.HasOne(e => e.User)
                .WithOne(u => u.Nota)
                .HasForeignKey<Nota>(e => e.UserId);  // Chave estrangeira no tipo int
        });
    }
}