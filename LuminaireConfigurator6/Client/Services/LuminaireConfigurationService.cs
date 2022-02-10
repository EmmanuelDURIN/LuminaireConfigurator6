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
    public async Task PostLuminaireConfiguration(LuminaireConfiguration luminaireConfiguration)
    {
      await httpClient.PostAsJsonAsync("luminaireconfiguration", luminaireConfiguration);
    }
    public async Task<(LuminaireConfiguration[] configurations, int totalConfigurations)>
       GetRangeWithDelay(int startIndex, int count, CancellationToken cancellationToken)
    {
      await Task.Delay(1000);
      return await GetRange(startIndex, count, cancellationToken);
    }
    public async Task<(LuminaireConfiguration[] configurations, int totalForeCasts)>
        GetRange(int startIndex, int count, CancellationToken cancellationToken)
    {
      int totalConfigurations = await httpClient.GetFromJsonAsync<int>("LuminaireConfiguration/count");
      var numConfigurations = Math.Min(count, totalConfigurations - startIndex);
      LuminaireConfiguration[] luminaireConfigurations = new LuminaireConfiguration[0];
      try
      {
        luminaireConfigurations = await httpClient.GetFromJsonAsync<LuminaireConfiguration[]>
              (
              $"LuminaireConfiguration/range?startIndex={startIndex}&numConfigurations={numConfigurations}"
              , cancellationToken
              ) ?? new LuminaireConfiguration[0];

      }
      catch (TaskCanceledException)
      {
        Console.WriteLine("Task cancelled");
      }
      catch (OperationCanceledException)
      {
        Console.WriteLine("Operation cancelled");
      }
      Console.WriteLine($"returning from {startIndex} to {startIndex + numConfigurations}");
      return (luminaireConfigurations, totalConfigurations);
    }
  }
}
