using LuminaireConfigurator6.Client.ViewModel;
using Microsoft.AspNetCore.Components.Forms;

namespace LuminaireConfigurator6.Client.Pages
{
  public partial class ConfigurationCreation
  {
    public EditContext EditContext { get; set; }
    private ValidationMessageStore messageStore;
    public bool IsModified { get => EditContext.IsModified(); }
    public LuminaireConfiguration Configuration { get; set; } = new LuminaireConfiguration();
    public int[] LampColors { get; set; } = new int[] { 2200, 2700, 3000, 4000, 5700 };
    public string[] Optics { get; set; } = new string[] { "ON10", "ON11", "OL10", "OL11", "OM10", "OM11" };
    public ConfigurationCreation()
    {
      EditContext = new(Configuration);
      messageStore = new(EditContext);
      EditContext.OnValidationRequested += HandleValidationRequested;
      EditContext.OnFieldChanged += EditContextFieldChanged;
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
