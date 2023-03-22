using LuminaireConfigurator6.Shared.Delivery;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class DeliveryCenter : IDeliveryCenterNotification, IAsyncDisposable
  {
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    private List<LuminaireConfiguration> luminaireConfigurations = new List<LuminaireConfiguration>();
    public List<LuminaireConfiguration> LuminaireConfigurations
    {
      get => luminaireConfigurations;
      set => luminaireConfigurations = value;
    }
    [Parameter]
    public EventCallback<LuminaireConfiguration> LuminaireConfigurationChanged { get; set; }
    private LuminaireConfiguration? selectedConfiguration;
    [Parameter]
    public LuminaireConfiguration? SelectedConfiguration
    {
      get { return selectedConfiguration; }
      set 
      {
        Console.WriteLine($"Trying to select value:{value?.Name}, selectedConfiguration:{selectedConfiguration?.Name}" );
        if (selectedConfiguration != value)
        {
            selectedConfiguration = value;
            LuminaireConfigurationChanged.InvokeAsync(value);
        }
      }
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
        await Console.Out.WriteLineAsync(  "Delivering configuration" );
        await hubConnection.InvokeAsync("ConfigurationDelivered", SelectedConfiguration);
      }
    }
    protected async override Task OnInitializedAsync()
    {
      await ConnectToHub();
    }
    public Task OnConfigurationDelivered(LuminaireConfiguration lumConf)
    {
      Console.WriteLine("Client got delivery removed");
      if (lumConf.Equals(SelectedConfiguration)) 
        SelectedConfiguration = null;
      LuminaireConfigurations.Remove(lumConf);
      StateHasChanged();
      return Task.CompletedTask;
    }
    public async ValueTask DisposeAsync()
    {
      if(hubConnection!=null)
        await hubConnection.StopAsync();
    }
  }
}
