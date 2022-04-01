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
      builder.Entity<Dog>()
        .HasData(
        new Dog { DogId = 1, Name = "Mathias McDog", Gender = "Male", Age = 1 },
        new Dog { DogId = 2, Name = "Sally Sandwichstealer", Gender = "Female", Age = 2 },
        new Dog { DogId = 3, Name = "Peter Poopeater", Gender = "Male", Age = 2 },
        new Dog { DogId = 4, Name = "Samantha Sniffsalot", Gender = "Female", Age = 3 }
      );

      builder.Entity<Cat>()
        .HasData(
        new Cat { CatId = 1, Name = "Catrina McMeow", Gender = "Female", Age = 1 },
        new Cat { CatId = 2, Name = "Henry Hiss", Gender = "Male", Age = 2 },
        new Cat { CatId = 3, Name = "Pamela Pushitoff", Gender = "Female", Age = 2 },
        new Cat { CatId = 4, Name = "Benjamin Bartholomeow", Gender = "Male", Age = 3 }
      );
    }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Cat> Cats { get; set; }
  }
}