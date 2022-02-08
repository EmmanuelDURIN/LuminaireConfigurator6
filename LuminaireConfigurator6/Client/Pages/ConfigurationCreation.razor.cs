using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components.Forms;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ConfigurationCreation
  {
    public EditContext EditContext { get; set; }
    private ValidationMessageStore messageStore;
    public bool IsModified { get => EditContext.IsModified(); }
    public ViewModel.LuminaireConfiguration Configuration { get; set; } = new ();
    public List<LampColor> LampColors { get; set; } = new ();
    public List<Optic> Optics { get; set; } = new ();
    public ConfigurationCreation()
    {
      EditContext = new(Configuration);
      messageStore = new(EditContext);
      EditContext.OnValidationRequested += HandleValidationRequested;
      EditContext.OnFieldChanged += EditContextFieldChanged;
    }
    protected async override Task OnInitializedAsync()
    {
      var opticService = new OpticService();
      Optics = await opticService.GetOptics();
      var lampColorService = new LampColorService();
      LampColors = await lampColorService.GetLampColors();
      await base.OnInitializedAsync();
    }
    public void Create()
    {
      Console.WriteLine("configuration created");
    }
    private void EditContextFieldChanged(object? sender, FieldChangedEventArgs e)
    {
    }
    private void HandleValidationRequested(object? sender, ValidationRequestedEventArgs args)
    {
      messageStore.Clear();
      // Custom validation logic
      //if (!Configuration.Options)
      //{
      //  messageStore?.Add(() => Configuration.Options, "Select at least one.");
      //}
    }
  }
}
