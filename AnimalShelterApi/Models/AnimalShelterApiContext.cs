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
    public DbSet<Branch> Branches { get; set; }
    // public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

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
          IsFixed = true,
          BranchId = 1
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
          IsFixed = true,
          BranchId = 1
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
          IsFixed = true,
          BranchId = 2
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
          IsFixed = true,
          BranchId = 2
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
          IsFixed = true,
          BranchId = 1
        }
      );
      builder.Entity<Branch>().HasData
      (
        new Branch
        {
          Id = 1,
          Name = "Flagstaff Humane Society",
          Address = "1800 S. Milton Road, Flagstaff, AZ 86001"
        },
        new Branch
        {
          Id = 2,
          Name = "Kingman Human Society",
          Address = "2990 Andy Devine Ave, Kingman, AZ, 86401"
        }
      );

    }
  }
}