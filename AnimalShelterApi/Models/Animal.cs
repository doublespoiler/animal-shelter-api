using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Animal
  {

    public Animal() { }

    public int Id { get; set; }
    [Required]
    public string Sex { get; set; }
    [Required]
    public string Name { get; set; }
    public int Age { get; set; } = 0;
    [Required]
    public string Species { get; set; }
    public string Breed { get; set; } = "Mixed";
    public string Color { get; set; }
    public bool IsFixed { get; set; } = false;
    [Required]
    public int BranchId { get; set; }
    [JsonIgnore]
    public virtual Branch branch { get; set; }
  }
}