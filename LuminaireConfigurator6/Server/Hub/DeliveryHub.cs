using LuminaireConfigurator6.Server.Controllers;
using LuminaireConfigurator6.Shared.Delivery;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.SignalR;

namespace LuminaireConfigurator6.Server.Hub
{
  public class DeliveryHub : Hub<IDeliveryCenterNotification>
  {
    public List<LuminaireConfiguration> GetDeliveries()
    {
      return LuminaireConfigurationController.LuminaireConfigurations;
    }
    public void ConfigurationDelivered(LuminaireConfiguration configuration)
    {
      LuminaireConfigurationController.LuminaireConfigurations.Remove(configuration);

      Console.WriteLine("Call made on server");
      // Add code to call OnConfigurationDelivered on client side
      // through SignalR, passing the LuminaireConfiguration
    }

  }
}
