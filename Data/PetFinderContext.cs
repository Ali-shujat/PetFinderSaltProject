using Microsoft.EntityFrameworkCore;
using PetFinderApi.Models;

namespace PetFinderApi.Data;

public class PetFinderContext : DbContext
{
    public PetFinderContext(DbContextOptions<PetFinderContext> options)
        : base(options)
    {
    }

    public DbSet<Cat> Cat { get; set; } = default!;

    public DbSet<Person> Person { get; set; } = default!;

    public DbSet<Wanting> Wanting { get; set; } = default!;

    public DbSet<Sighting> Sighting { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) // The DB options should be set from the active project (i.e. live or test)
            optionsBuilder.UseSqlServer("PetFinderContext" ??
                                        throw new InvalidOperationException(
                                            "Connection string 'PetFinderContext' not found."));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Image)
                .HasMaxLength(50);

            entity.Property(e => e.AdditionalInfo)
                .HasMaxLength(500);

            entity.Property(e => e.Breed)
                .HasMaxLength(20);

            entity.Property(e => e.Size)
                .HasMaxLength(10);

            entity.Property(e => e.Eyecolor)
                .HasMaxLength(10);

            entity.Property(e => e.CoatLength)
                .HasMaxLength(20);

            entity.Property(e => e.Gender)
                .HasMaxLength(10);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName)
                .HasMaxLength(50);

            entity.Property(e => e.Surname)
                .HasMaxLength(50);

            entity.Property(e => e.Phone)
                .HasMaxLength(15);

            entity.Property(e => e.Email)
                .HasMaxLength(20);
        });

        modelBuilder.Entity<Wanting>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.EventInfo)
                .HasMaxLength(500);
        });

        modelBuilder.Entity<Sighting>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.EventInfo)
                .HasMaxLength(500);
        });
    }
}