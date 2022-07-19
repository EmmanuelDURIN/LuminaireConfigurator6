using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ConfigurationDetails
  {
    [Inject]
    // ! null forgiving operator 
    public NavigationManager NavigationManager { get; set; } = null!;
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
      LuminaireConfigurationService luminaireConfigurationService = new LuminaireConfigurationService();
      Configuration = luminaireConfigurationService.GetLuminaireConfigurationById(Id);
      if (Configuration == null)
        NavigationManager.NavigateTo("NotFound");
      return Task.FromResult(0);
    }
  }
}
