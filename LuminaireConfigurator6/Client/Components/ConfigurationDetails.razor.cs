using LuminaireConfigurator6.Client.Pages;
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
    private ISelectionProvider? selectionProvider;
    [CascadingParameter(Name = "SelectionProvider")]
    public ISelectionProvider? SelectionProvider
    {
      get { return selectionProvider; }
      set { 
        selectionProvider = value;
        if (selectionProvider != null)
        {
          selectionProvider.PropertyChanged += SelectionProviderPropertyChanged; ;
        }
      }
    }
    private void SelectionProviderPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(ISelectionProvider.SelectedConfiguration) 
        && selectionProvider !=null)
      {
        configuration = selectionProvider.SelectedConfiguration;
        StateHasChanged();
      }
    }
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
    //protected async override Task OnInitializedAsync()
    //{
    //  if (LuminaireConfigurationService != null)
    //    Configuration = await LuminaireConfigurationService.GetLuminaireConfigurationById(Id);
    //  if (Configuration == null && NavigationManager != null)
    //    NavigationManager.NavigateTo("NotFound");
    //}
  }
}
