using LuminaireConfigurator6.Shared.Model;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LuminaireConfigurator6.Client.Services
{
  public class LuminaireConfigurationService : ILuminaireConfigurationService
  {
    private readonly HttpClient httpClient;
    public LuminaireConfigurationService(HttpClient httpClient)
    {
      this.httpClient = httpClient;
    }
    public async Task<LuminaireConfiguration?> GetLuminaireConfigurationById(int id)
    {
      var lumConf = await httpClient.GetFromJsonAsync<LuminaireConfiguration>("luminaireconfiguration/"+id);
      return lumConf;
    }
    public async Task<List<LuminaireConfiguration>> GetLuminaireConfigurations()
    {
      var lumConfs = await httpClient.GetFromJsonAsync<List<LuminaireConfiguration>>("luminaireconfiguration");
      return lumConfs??new List<LuminaireConfiguration>();
    }

    public async Task<LuminaireConfiguration?> PostLuminaireConfiguration(LuminaireConfiguration luminaireConfiguration)
    {
      HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("luminaireconfiguration", luminaireConfiguration);
      httpResponseMessage.EnsureSuccessStatusCode();
      if (httpResponseMessage.IsSuccessStatusCode)
      {
        LuminaireConfiguration? createdLuminaireConfiguration = await httpResponseMessage.Content.ReadFromJsonAsync<LuminaireConfiguration>();
        return createdLuminaireConfiguration;
        //int id = 0;
        //if (int.TryParse(httpResponseMessage.Headers.Location?.Segments.LastOrDefault(), out id))
        //{
        //  return new LuminaireConfiguration { Id = id };
        //}
      }
      return null;
    }
  }
}
