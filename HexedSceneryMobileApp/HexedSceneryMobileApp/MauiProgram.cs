
using HexedSceneryMobileApp.Helpers;
using HexedSceneryMobileApp.Services;
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

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddSingleton<IDiceRollHelper, DiceRollHelper>();

            // Add dummy data instead of getting data from api
            
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
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                logging.AddDebug();
            });

            if (!OperatingSystem.IsWindows())
            {
                builder.Services.AddSingleton<IEncounterService, DummyData>();
                builder.Services.AddSingleton<IMenuService, DummyData>();
                builder.Services.AddSingleton<IHiredSwordService, DummyData>();
                builder.Services.AddSingleton<IDiceService, DummyData>();
            }
            else
            {
                builder.Services.AddSingleton<IEncounterService, EncounterService>();
                builder.Services.AddSingleton<IMenuService, MenuService>();
                builder.Services.AddSingleton<IHiredSwordService, HiredSwordService>();
                builder.Services.AddSingleton<IDiceService, DiceService>();
                builder.Services.AddSingleton<IMonsterService, MonsterService>();
                var logService = new LogService(Enums.LogLevel.Debug);
                builder.Services.AddSingleton<ILogService>(m => logService);
            }
#endif


            return builder.Build();
        }
    }
}
