using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class MasterDetail
  {
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
