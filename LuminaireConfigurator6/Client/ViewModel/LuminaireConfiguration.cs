using System.ComponentModel.DataAnnotations;

namespace LuminaireConfigurator6.Client.ViewModel
{
  public class LuminaireConfiguration
  {
    [Required]
    public string Name { get; set; } = "";
    [Range(1,1E10)]
    public double LampFlux { get; set; }
    public decimal Price { get; set; }
    [Required]
    public string Optic { get; set; } = "";
    [Range(1,1E6)]
    public int LampColor { get; set; }
  }
}
