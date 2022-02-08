using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ConfigurationList
  {
    [Inject]
    public ILuminaireConfigurationService? LuminaireConfigurationService { get; set; }
    private List<LuminaireConfiguration>? luminaireConfigurations = null;
    public List<LuminaireConfiguration>? LuminaireConfigurations
    {
      get => luminaireConfigurations;
      set => luminaireConfigurations = value;
    }

    protected override async Task OnInitializedAsync()
    {
      base.OnInitialized();
      if (LuminaireConfigurationService != null)
        luminaireConfigurations = await LuminaireConfigurationService.GetLuminaireConfigurations();
    }
  }
}
