using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Branch
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [JsonIgnore]
    public virtual ICollection<Animal> Animals { get; set; }

    public Branch()
    {
      this.Animals = new HashSet<Animal>();
    }
  }
}