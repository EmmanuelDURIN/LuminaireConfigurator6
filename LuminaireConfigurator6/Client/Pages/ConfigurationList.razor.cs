using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ConfigurationList
  {
    private List<LuminaireConfiguration>? luminaireConfigurations = null;
    public List<LuminaireConfiguration>? LuminaireConfigurations
    {
      get => luminaireConfigurations;
      set => luminaireConfigurations = value;
    }

    protected override async  Task OnInitializedAsync()
    {
      base.OnInitialized();
      luminaireConfigurations = await new LuminaireConfigurationService().GetLuminaireConfigurations();
    }
  }
}
