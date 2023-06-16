using LuminaireConfigurator6.Shared.Model;
using System.Net.Http.Json;

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
        public async Task<LuminaireConfiguration?> GetLuminaireConfigurationById(int id)
        {
            string requestUri = $"{nameof(LuminaireConfiguration)}/{id}";
            LuminaireConfiguration? luminaireConfiguration = await httpClient.GetFromJsonAsync<LuminaireConfiguration>(requestUri);
            return luminaireConfiguration;
        }
        public async Task<List<LuminaireConfiguration>> GetLuminaireConfigurations()
        {
            string requestUri = nameof(LuminaireConfiguration);
            List<LuminaireConfiguration>? luminaireConfigurations
                = await httpClient.GetFromJsonAsync<List<LuminaireConfiguration>>(requestUri);
            return luminaireConfigurations ?? new List<LuminaireConfiguration>();
        }
        public async Task PostLuminaireConfiguration(LuminaireConfiguration luminaireConfiguration)
        {
            string requestUri = nameof(LuminaireConfiguration);
            //LuminaireConfiguration luminaireConfigurations
            HttpResponseMessage httpResponseMessage
                = await httpClient.PostAsJsonAsync(requestUri, luminaireConfiguration);
        }
    }
}
