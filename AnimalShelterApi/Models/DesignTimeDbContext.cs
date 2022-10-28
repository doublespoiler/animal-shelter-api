using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterContextFactory : IDesignTimeDbContextFactory<AnimalShelterContext>
  {

    AnimalShelterContext IDesignTimeDbContextFactory<AnimalShelterContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<AnimalShelterContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new AnimalShelterContext(builder.Options);
    }
  }
}