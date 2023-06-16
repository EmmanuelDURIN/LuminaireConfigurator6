using LuminaireConfigurator6.Client.Services;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator6.Client.Pages
{
    public partial class ConfigurationList
    {
        // 2) déclaration de dépendance, et demande d'injection
        [Inject]
        // ! null forgiving operator
        public ILuminaireConfigurationService LuminaireConfigurationService { get; set; } = null!;

        private List<LuminaireConfiguration>? luminaireConfigurations = null;
        public List<LuminaireConfiguration>? LuminaireConfigurations
        {
            get => luminaireConfigurations;
            set => luminaireConfigurations = value;
        }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
            luminaireConfigurations = await LuminaireConfigurationService.GetLuminaireConfigurations();
            //luminaireConfigurations = await new LuminaireConfigurationService().GetLuminaireConfigurations();
        }
    }
}
