using LuminaireConfigurator6.Shared.Model;
using System.Net.Http.Json;

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
  }
}
