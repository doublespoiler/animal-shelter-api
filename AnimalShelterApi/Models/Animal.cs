using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApi.Models
{
  public class Animal
  {
    public int Id { get; set; }
    public string Sex { get; set; }
    public string Name { get; set; }
    public int Age { get; set; } = 0;
    public string Species { get; set; }
    public string Breed { get; set; } = "Mixed";
    public string Color { get; set; }
    public bool IsFixed { get; set; } = false;
  }
}