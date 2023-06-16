using LuminaireConfigurator6.Client;
using LuminaireConfigurator6.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// 1) Déclaration de la classe LuminaireConfigurationService dans le système DI,
// exposée en tant que ILuminaireConfigurationService
builder.Services.AddTransient< ILuminaireConfigurationService, LuminaireConfigurationService >();

await builder.Build().RunAsync();
