using LuminaireConfigurator6.Shared.Model;

namespace LuminaireConfigurator6.Client.Services
{
  public interface ILuminaireConfigurationService
  {
    Task<LuminaireConfiguration?> GetLuminaireConfigurationById(int id);
    Task<List<LuminaireConfiguration>> GetLuminaireConfigurations();
  }
}