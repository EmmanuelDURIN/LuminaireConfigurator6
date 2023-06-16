using LuminaireConfigurator6.Shared.Model;

namespace LuminaireConfigurator6.Client.Services
{
    public class LuminaireConfigurationService : ILuminaireConfigurationService
    {
        private readonly HttpClient httpClient;
        // 3) on se fait injecter HttpClient, par le système DI
        public LuminaireConfigurationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private List<LuminaireConfiguration> luminaireConfigurations = new List<LuminaireConfiguration>()
            {
              new LuminaireConfiguration
              {
                Id=1,
                CreationTime = new DateTime(2020,11,8),
                LampColor = 5400,
                LampFlux = 2000,
                Optic = "OM10",
                Name="Luminaires Nanterre"
              },
              new LuminaireConfiguration
              {
                Id=2,
                CreationTime = new DateTime(2020,12,9),
                LampColor = 5700,
                LampFlux = 3000,
                Optic = "OM11",
                Name="Luminaires Courbevoie"
              },
              new LuminaireConfiguration
              {
                Id=3,
                CreationTime = new DateTime(2021,1,4),
                LampColor = 5700,
                LampFlux = 10000,
                Optic = "OM12",
                Name="Luminaires Puteaux"
              },
            };
        public Task<LuminaireConfiguration?> GetLuminaireConfigurationById(int id)
        {
            return Task.FromResult(luminaireConfigurations.FirstOrDefault(lc => lc.Id == id));
        }
        public async Task<List<LuminaireConfiguration>> GetLuminaireConfigurations()
        {
            await Task.Delay(500);
            return luminaireConfigurations;
        }
    }
}
