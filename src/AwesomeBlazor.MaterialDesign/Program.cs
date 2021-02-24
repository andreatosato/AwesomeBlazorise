using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AwesomeBlazor.MaterialDesign
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services
               .AddBlazorise(options =>
               {
                   options.ChangeTextOnKeyPress = true;
               })
               .AddMaterialProviders()
               .AddMaterialIcons();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.RootComponents.Add<App>("#app");

            var host = builder.Build();

            host.Services
                .UseMaterialProviders()
                .UseMaterialIcons();

            await host.RunAsync();
        }
    }
}
