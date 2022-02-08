using LuminaireConfigurator6.Client.ViewModel;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ConfigurationCreation
  {
    public LuminaireConfiguration Configuration { get; set; } = new LuminaireConfiguration();
    public void Create()
    {
      Console.WriteLine("configuration created");
    }

  }
}
