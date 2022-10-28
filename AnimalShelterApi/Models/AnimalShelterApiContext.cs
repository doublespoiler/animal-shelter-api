using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>().HasData
      (
        new Animal
        {
          Id = 1,
          Sex = "male",
          Name = "Titan",
          Age = 6,
          Species = "canine",
          Breed = "pit bull mix",
          Color = "White",
          IsFixed = true
        },
        new Animal
        {
          Id = 2,
          Sex = "male",
          Name = "Milo",
          Age = 3,
          Species = "canine",
          Breed = "pit bull mix",
          Color = "brown",
          IsFixed = true
        },
        new Animal
        {
          Id = 3,
          Sex = "female",
          Name = "Korra",
          Age = 4,
          Species = "canine",
          Breed = "Shepherd Mix",
          Color = "Black",
          IsFixed = true
        },
        new Animal
        {
          Id = 4,
          Sex = "male",
          Name = "Sid",
          Age = 1,
          Species = "feline",
          Breed = "american shorthair",
          Color = "black",
          IsFixed = true
        },
        new Animal
        {
          Id = 5,
          Sex = "female",
          Name = "Maeve",
          Age = 1,
          Species = "feline",
          Breed = "mixed",
          Color = "tabby",
          IsFixed = true
        }
      );
    }
  }
}