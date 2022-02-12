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
      Console.WriteLine("Call made on server");
      if (LuminaireConfigurationController.LuminaireConfigurations.Remove(configuration))
      {
        // Add code to call OnConfigurationDelivered on client side
        // through SignalR, passing the LuminaireConfiguration
        Clients.All.OnConfigurationDelivered(configuration);
      }
    }
  }
}
