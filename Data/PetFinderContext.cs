using Microsoft.EntityFrameworkCore;
using PetFinderApi.Models;

namespace PetFinderApi.Data;

public class PetFinderContext : DbContext
{
    public PetFinderContext(DbContextOptions<PetFinderContext> options)
        : base(options)
    {
       if(!Wanting.Any()) Seed();
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
    
    private void Seed()
    {
      //  Database.EnsureDeleted(); 
      //  Database.EnsureCreated();

        var firstWanting = new Wanting
        {
            Latitud = 59.323,
            Longitud = 18.0753,
            EventInfo = "We left our front door open at Tullgränd when she ran out. She is friendly and will come up to greet most people.",
            Cat = new Cat
            {
                Name ="Missie",
                AdditionalInfo = "Her left front paw is white. She loves fish",
                Owner = new Person
                {
                    FirstName = "Maria Johansson",
                    Phone = "08-580 900 10",
                    Email = "maria.johansson@hotmail.com"
                }
            }
        };
        
        var secondWanting = new Wanting
        {
            Latitud = 59.325,
            Longitud = 18.067,
            EventInfo = "Our dear kittie is missing. He loves to hide in small spaces. The kids are so sad. We will give you finders fee!",
            Cat = new Cat
            {
                Name ="Mr Fluff",
                AdditionalInfo = "Is scared of men, please don't try to catch him just call us if you see him!",
                Owner = new Person
                {
                    FirstName = "Calle Molin",
                    Phone = "0730 - 77 89 90",
                    Email = "kattkille@msn.com"
                }
            }
        };
        
        var thirdWanting = new Wanting
        {
            Latitud = 59.3285,
            Longitud = 18.0493,
            EventInfo = "Fiona has now not come back for almost a week. She is an outdoor cat and usually hangs out in the cementary, but she usually comes back to eat in the evening. But now we haven't seen her, not even for feeding. Since it's quite cold outside we are verry worried. Please let us know ASAP if you see here <3",
            Cat = new Cat
            {
                Name ="Fiona",
                AdditionalInfo = "Very playful, loves to chase pidgeons",
                Owner = new Person
                {
                    FirstName = "Ali Darwish",
                    Phone = "070 - 177 99 55",
                    Email = "mrdarwish@gmail.com",
                }
            }
        };
        
        Wanting.AddRange(firstWanting, secondWanting, thirdWanting);
        SaveChanges();
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