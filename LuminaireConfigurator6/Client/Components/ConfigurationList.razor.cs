using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Components
{
  public partial class ConfigurationList : ComponentBase
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

    private LuminaireConfiguration? selectedConfiguration;
    [Parameter]
    public LuminaireConfiguration? SelectedConfiguration
    {
      get { return selectedConfiguration; }
      set
      {
        if (selectedConfiguration != value)
        {
          selectedConfiguration = value;
          SelectedConfigurationChanged.InvokeAsync(value);
        }
      }
    }
    [Parameter]
    public EventCallback<LuminaireConfiguration?> SelectedConfigurationChanged
    { get; set; }
  }
}
