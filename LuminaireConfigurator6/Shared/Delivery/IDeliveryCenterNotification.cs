using LuminaireConfigurator6.Shared.Model;

namespace LuminaireConfigurator6.Shared.Delivery
{
  public interface IDeliveryCenterNotification
  {
    Task OnConfigurationDelivered(LuminaireConfiguration configuration);
  }
}
