using LuminaireConfigurator6.Shared.Model;

namespace LuminaireConfigurator6.Client.Services
{
  public interface ILuminaireConfigurationService
  {
    Task<LuminaireConfiguration?> GetLuminaireConfigurationById(int id);
    Task<List<LuminaireConfiguration>> GetLuminaireConfigurations();
    Task<(LuminaireConfiguration[] configurations, int totalConfigurations)>
    GetRangeWithDelay(int startIndex, int count, CancellationToken cancellationToken);
    Task<(LuminaireConfiguration[] configurations, int totalForeCasts)>
    GetRange(int startIndex, int count, CancellationToken cancellationToken);
    Task<LuminaireConfiguration?> PostLuminaireConfiguration(LuminaireConfiguration luminaireConfiguration);
  }
}