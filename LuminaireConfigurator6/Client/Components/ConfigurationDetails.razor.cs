using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Components
{
  public partial class ConfigurationDetails : ComponentBase
  {
    [Inject]
    public ILuminaireConfigurationService? LuminaireConfigurationService { get; set; }
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    private int id;
    [Parameter]
    public int Id { get => id; set => id = value; }
    private LuminaireConfiguration? configuration;
    [Parameter]
    public LuminaireConfiguration? Configuration
    {
      get => configuration;
      set => configuration = value;
    }
    public ConfigurationDetails()
    {
    }
    public override async Task SetParametersAsync(ParameterView parameters)
    {
      await base.SetParametersAsync(parameters);
    }
    protected override Task OnParametersSetAsync()
    {
      return base.OnParametersSetAsync();
    }
  }
}
