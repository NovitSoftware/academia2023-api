using NovitSoftware.Academia.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace NovitSoftware.Academia.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity => {
            entity.ToTable("User");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .IsRequired();

            entity.Property(n => n.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(n => n.Username)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(n => n.PasswordHash)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasMany(x => x.Roles)
                .WithMany(x => x.Users);
            });

        modelBuilder.Entity<Role>(entity => {
            entity.ToTable("Role");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .IsRequired();

            entity.Property(n => n.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity.HasMany(x => x.Users)
                .WithMany(x => x.Roles);
        });
    }
}
