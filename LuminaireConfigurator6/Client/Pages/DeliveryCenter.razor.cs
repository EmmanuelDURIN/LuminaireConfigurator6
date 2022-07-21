using LuminaireConfigurator6.Shared.Delivery;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class DeliveryCenter : IDeliveryCenterNotification
  {
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    private List<LuminaireConfiguration> luminaireConfigurations = new List<LuminaireConfiguration>();
    public List<LuminaireConfiguration> LuminaireConfigurations
    {
      get => luminaireConfigurations;
      set => luminaireConfigurations = value;
    }
    private LuminaireConfiguration? selectedConfiguration;
    public LuminaireConfiguration? SelectedConfiguration
    {
      get { return selectedConfiguration; }
      set { selectedConfiguration = value; }
    }
    private HubConnection? hubConnection = null;
    private async Task ConnectToHub()
    {
      if (NavigationManager == null)
        throw new NullReferenceException(nameof(NavigationManager));
      hubConnection = new HubConnectionBuilder()
          .WithUrl(NavigationManager.ToAbsoluteUri("/deliveryhub"))
          .Build();
      hubConnection.On<LuminaireConfiguration>(nameof(IDeliveryCenterNotification.OnConfigurationDelivered),
                                               OnConfigurationDelivered);
      await hubConnection.StartAsync();
      luminaireConfigurations = await hubConnection.InvokeAsync<List<LuminaireConfiguration>>("GetDeliveries");
    }
    private async Task Deliver()
    {
      if (SelectedConfiguration != null && hubConnection != null)
      {
        await hubConnection.InvokeAsync("ConfigurationDelivered", SelectedConfiguration);
        SelectedConfiguration = null;
      }
    }
    protected async override Task OnInitializedAsync()
    {
      await ConnectToHub();
    }
    public Task OnConfigurationDelivered(LuminaireConfiguration lumConf)
    {
      Console.WriteLine("Client got delivery removed");
      LuminaireConfigurations.Remove(lumConf);
      StateHasChanged();
      return Task.CompletedTask;
    }
  }
}
