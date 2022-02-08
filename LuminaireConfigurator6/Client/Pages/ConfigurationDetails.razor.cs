using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ConfigurationDetails
  {
    [Inject]
    public ILuminaireConfigurationService? LuminaireConfigurationService { get; set; }
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    private int id;
    [Parameter]
    public int Id { get => id; set => id = value; }
    private LuminaireConfiguration? configuration;
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
    protected override Task OnInitializedAsync()
    {
      if (LuminaireConfigurationService != null)
        Configuration = LuminaireConfigurationService.GetLuminaireConfigurationById(Id);
      if (Configuration == null && NavigationManager != null)
        NavigationManager.NavigateTo("NotFound");
      return Task.FromResult(0);
    }
  }
}
