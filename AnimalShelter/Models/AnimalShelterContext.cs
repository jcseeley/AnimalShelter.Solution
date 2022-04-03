using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
        new Animal { AnimalId = 1, Type = "Dog", Name = "Mathias McDog", Gender = "Male", Age = 1 },
        new Animal { AnimalId = 2, Type = "Dog", Name = "Sally Sandwichstealer", Gender = "Female", Age = 2 },
        new Animal { AnimalId = 3, Type = "Dog", Name = "Peter Poopeater", Gender = "Male", Age = 2 },
        new Animal { AnimalId = 4, Type = "Dog", Name = "Samantha Sniffsalot", Gender = "Female", Age = 3 },
        new Animal { AnimalId = 5, Type = "Cat", Name = "Catrina McMeow", Gender = "Female", Age = 1 },
        new Animal { AnimalId = 6, Type = "Cat", Name = "Henry Hiss", Gender = "Male", Age = 2 },
        new Animal { AnimalId = 7, Type = "Cat", Name = "Pamela Pushitoff", Gender = "Female", Age = 2 },
        new Animal { AnimalId = 8, Type = "Cat", Name = "Benjamin Bartholomeow", Gender = "Male", Age = 3 }
      );
    }
    public DbSet<Animal> Animals { get; set; }
  }
}