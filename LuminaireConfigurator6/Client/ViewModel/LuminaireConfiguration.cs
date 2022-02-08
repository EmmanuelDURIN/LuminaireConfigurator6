using LuminaireConfigurator6.Shared.Model;
using System.ComponentModel.DataAnnotations;

namespace LuminaireConfigurator6.Client.ViewModel
{
  public class LuminaireConfiguration
  {
    [Required]
    public string Name { get; set; } = "";
    [Range(1, 1E10)]
    public double LampFlux { get; set; }
    public decimal Price { get; set; }
    [Required]
    public Optic Optic { get; set; } = new Optic { Id = 1, Name = "OM10" };
    [Required]
    public LampColor LampColor { get; set; } = new LampColor { Id = 1, Temperature = 2200 };
  }
}
