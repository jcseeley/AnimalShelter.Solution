using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Dog
  {
    public int DogId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name {get; set; }
    [Required]
    [StringLength(50)]
    public string Gender { get; set; }
    [Required]
    [Range(0, 150, ErrorMessage = "Age must be between 0 and 20.")]
    public int Age { get; set; }
  }
}