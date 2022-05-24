using System.Text.Json.Serialization;

namespace LuminaireConfigurator6.Shared.Model
{
  public class LuminaireConfiguration
  {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double LampFlux { get; set; }
    public decimal Price { get; set; }
    public string Optic { get; set; } = "";
    public DateTime CreationTime { get; set; }
    public int LampColor { get; set; }
  }
}
