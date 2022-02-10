using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ItemsProviderDemo
  {
    [Inject]
    private ILuminaireConfigurationService? LuminaireConfigurationService { get; set; }

    private LuminaireConfiguration[]? luminaireConfigurations;
    public LuminaireConfiguration[]? LuminaireConfigurations
    {
      get => luminaireConfigurations;
      set => luminaireConfigurations = value;
    }
    protected override Task OnInitializedAsync()
    {
      Console.WriteLine("Before Enumerable.Range");
      LuminaireConfigurations = Enumerable.Range(1, 500_000)
                                          .Select(
                                            i => new LuminaireConfiguration
                                            {
                                              Id = i,
                                              Name = "Luminaire" + i,
                                              CreationTime = DateTime.Now,
                                              LampColor = 3000 + (i % 2000),
                                              Optic = "OM" + (i % 10),
                                              LampFlux = 1000,
                                            })
                                          .ToArray();
      Console.WriteLine("After Enumerable.Range");
      return Task.FromResult(0);
    }
    private async ValueTask<ItemsProviderResult<LuminaireConfiguration>> LoadLuminaireConfigurations(
                                                                         ItemsProviderRequest request)
    {
      if (LuminaireConfigurationService != null)
      {
        (LuminaireConfiguration[] luminaireConfigurations, int totalConfigurations) =
          await LuminaireConfigurationService.GetRangeWithDelay(request.StartIndex,
                                         request.Count,
                                         request.CancellationToken);
        return new ItemsProviderResult<LuminaireConfiguration>(luminaireConfigurations, totalConfigurations);
      }
      else
        return new ItemsProviderResult<LuminaireConfiguration>(new LuminaireConfiguration[0], 0);
    }
  }
}
