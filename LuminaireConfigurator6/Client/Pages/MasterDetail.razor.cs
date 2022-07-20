using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class MasterDetail : ISelectionProvider
  {
    private LuminaireConfiguration? selectedConfiguration;
    public LuminaireConfiguration? SelectedConfiguration
    {
      get { return selectedConfiguration; }
      set
      {
        if (selectedConfiguration != value)
        {
          selectedConfiguration = value;
          SelectedConfigurationChanged.InvokeAsync(value);
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedConfiguration))); 
        }
      }
    }
    [Parameter]
    public EventCallback<LuminaireConfiguration?> SelectedConfigurationChanged
    { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
  }
}
