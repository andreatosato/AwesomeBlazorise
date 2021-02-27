using AwesomeBlazor.Services;
using AwesomeBlazor.Services.Abstractions;
using AwesomeBlazor.Services.Implementations;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBlazor.Bootstrap
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
               .AddBootstrapProviders()
               .AddFontAwesomeIcons();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IThemeService, ThemeService>(sp => new ThemeService
            {
                CurrentTheme = new Theme 
                {
                    BarOptions = new ThemeBarOptions { HorizontalHeight = "64px" },                   
                    ColorOptions = new ThemeColorOptions { Primary = "#A65529" },
                    BackgroundOptions = new ThemeBackgroundOptions { Primary = "#0288D1"},
                    InputOptions = new ThemeInputOptions { CheckColor = "#0288D1"},
                    SidebarOptions = new ThemeSidebarOptions { BackgroundColor = "#A65529" }                    
                }
            });
            builder.Services.AddHttpClient("themoviedb", h => h.BaseAddress = new Uri("https://api.themoviedb.org/3/"));
            builder.Services.AddScoped<ITMDbService, TMDbService>();

            builder.RootComponents.Add<App>("#app");

            var host = builder.Build();

            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
