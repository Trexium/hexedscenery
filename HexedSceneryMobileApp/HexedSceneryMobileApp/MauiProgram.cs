using HexedSceneryApiClient.Services;
using HexedSceneryMobileApp.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System.Net.Http;
using System.Reflection;

namespace HexedSceneryMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("CaslonAntique.ttf", "CaslonAntique");
                    fonts.AddFont("CaslonAntique-Bold.ttf", "CaslonAntiqueBold");
                    fonts.AddFont("CaslonAntique-BoldItalic.ttf", "CaslonAntiqueBoldItalic");
                    fonts.AddFont("CaslonAntique-Italic.ttf", "CaslonAntiqueItalic");
                    fonts.AddFont("Schoensperger.otf", "Schoensperger");
                });

            // Load appsettings.json
            using var appsettingsStream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream($"{Assembly.GetExecutingAssembly().GetName().Name}.appsettings.json");

            if (appsettingsStream != null)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonStream(appsettingsStream)
                    .Build();

                builder.Configuration.AddConfiguration(config);
            }

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();

            builder.Services.AddScoped<IMenuBuilder, MenuBuilder>();


            // Add dummy data instead of getting data from api
            builder.Services.AddSingleton<IEncounterService, EncounterService>();
            builder.Services.AddSingleton<IHiredSwordService, DummyData>();
            var test = builder.Configuration["ApiUrl"];
            builder.Services.AddHttpClient("HexedApi", client => 
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
                client.DefaultRequestHeaders.Add("ApiKey", builder.Configuration["ApiKey"]);
            });


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Services.AddLogging(logging =>
            {
                //logging.AddFilter("Microsoft.AspNetCore.Components.WebView", LogLevel.Trace);
                logging.SetMinimumLevel(LogLevel.Trace);
                logging.AddDebug();
            });

            if (!OperatingSystem.IsWindows())
            {
                builder.Services.AddSingleton<IEncounterService, DummyData>();
            }
            else
            {
                builder.Services.AddSingleton<IEncounterService, EncounterService>();
            }
#endif


            return builder.Build();
        }
    }
}
