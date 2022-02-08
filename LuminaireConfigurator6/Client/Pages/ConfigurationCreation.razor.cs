using LuminaireConfigurator6.Client.ViewModel;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ConfigurationCreation
  {
    public LuminaireConfiguration Configuration { get; set; } = new LuminaireConfiguration();
    public int[] LampColors { get; set; } = new int[] { 2200, 2700, 3000, 4000, 5700 };
    public string[] Optics { get; set; } = new string[] { "ON10", "ON11", "OL10", "OL11", "OM10", "OM11" };
    public void Create()
    {
      Console.WriteLine("configuration created");
    }
  }
}
