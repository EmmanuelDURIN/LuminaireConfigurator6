using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ItemsProviderDemo
  {
    private bool isFirstSetOfDataLoaded;
    [Inject]
    private ILuminaireConfigurationService? LuminaireConfigurationService { get; set; }

    private async ValueTask<ItemsProviderResult<LuminaireConfiguration>> LoadLuminaireConfigurations(
                                                                         ItemsProviderRequest request)
    {
      if (LuminaireConfigurationService != null)
      {
        (LuminaireConfiguration[] luminaireConfigurations, int totalConfigurations) =
          await LuminaireConfigurationService.GetRangeWithDelay(request.StartIndex,
                                         request.Count,
                                         request.CancellationToken);
        isFirstSetOfDataLoaded = true;
        return new ItemsProviderResult<LuminaireConfiguration>(luminaireConfigurations, totalConfigurations);
      }
      else
        return new ItemsProviderResult<LuminaireConfiguration>(new LuminaireConfiguration[0], 0);
    }
  }
}
