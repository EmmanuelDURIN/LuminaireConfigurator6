using LuminaireConfigurator6.Shared.Model;

namespace LuminaireConfigurator6.Client.Services
{
  public class LampColorService
  {
    private List<LampColor> lampColors = new List<LampColor>()
            {
              new LampColor
              {
                Id=1,
                Temperature=2200
              },
              new LampColor
              {
                Id=2,
                Temperature=3700
              },
              new LampColor
              {
                Id=3,
                Temperature=4700
              },
            };
    public async Task<List<LampColor>> GetLampColors()
    {
      await Task.Delay(300);

      return lampColors;
    }
  }
}
