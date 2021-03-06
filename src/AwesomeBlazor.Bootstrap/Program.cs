using AwesomeBlazor.Services;
using AwesomeBlazor.Services.Abstractions;
using AwesomeBlazor.Services.Implementations;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
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
                    BarOptions = new ThemeBarOptions {
                        HorizontalHeight = "64px",
                        DarkColors = new ThemeBarColorOptions {
                            BackgroundColor = "#3E505B", 
                            Color = "#1A1D1A", 
                            BrandColorOptions = new ThemeBarBrandColorOptions { BackgroundColor = "#3E505B" },
                            DropdownColorOptions = new ThemeBarDropdownColorOptions { BackgroundColor = "#3E505B" },
                            ItemColorOptions = new ThemeBarItemColorOptions { ActiveBackgroundColor = "#26413C", ActiveColor = "#FFFFFF", HoverBackgroundColor = "#536B79", HoverColor = "#FFFFFF" } } },                   
                    ColorOptions = new ThemeColorOptions { Primary = "#A65529" },
                    BackgroundOptions = new ThemeBackgroundOptions { Primary = "#3E505B", Body = "#26413C" },
                    InputOptions = new ThemeInputOptions { CheckColor = "#0288D1"},
                    SidebarOptions = new ThemeSidebarOptions { BackgroundColor = "#A65529" }                    
                }
            });
            builder.Services.AddLocalization();
            builder.Services.AddHttpClient("themoviedb", h => {
                h.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                h.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI1ZDg2ZmJiZDAzYWFhZGE2MzY1MWQ1NjFhYTkyNjk1NSIsInN1YiI6IjYwMzJjN2UyMWZiOTRmMDAzZjhlYjFlYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.Ti-FDj_bD9aREXdJZVObrKJrgMgQXG097UjLmlKbDUE");
            });
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<ITMDbService, TMDbService>();

            builder.RootComponents.Add<App>("#app");

            var host = builder.Build();
            await SetBrowserCulture(host).ConfigureAwait(false);

            await host.RunAsync();
        }

        private static async Task SetBrowserCulture(WebAssemblyHost host)
        {
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
            if (result != null)
            {
                var culture = new CultureInfo(result);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }
        }
    }
}
