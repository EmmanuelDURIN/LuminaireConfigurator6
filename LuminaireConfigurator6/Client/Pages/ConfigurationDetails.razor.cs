using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Pages
{
    public partial class ConfigurationDetails
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        [Inject]
        // ! null forgiving operator
        public ILuminaireConfigurationService LuminaireConfigurationService { get; set; } = null!;
        private int id;
        [Parameter]
        public int Id { get => id; set => id = value; }
        private LuminaireConfiguration? configuration;
        public LuminaireConfiguration? Configuration
        {
            get => configuration;
            set => configuration = value;
        }
        public ConfigurationDetails()
        {
        }
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
        }
        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }
        protected async override Task OnInitializedAsync()
        {
            //LuminaireConfigurationService luminaireConfigurationService = new LuminaireConfigurationService();
            //Configuration = await luminaireConfigurationService.GetLuminaireConfigurationById(Id);
            Configuration = await LuminaireConfigurationService.GetLuminaireConfigurationById(Id);
            if (Configuration == null && NavigationManager != null)
                NavigationManager.NavigateTo("NotFound");
        }
    }
}
