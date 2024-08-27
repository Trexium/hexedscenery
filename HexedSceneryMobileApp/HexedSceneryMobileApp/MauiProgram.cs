using HexedSceneryData.Services;
using HexedSceneryMobileApp.Helpers;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System.Net.Http;

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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();

            builder.Services.AddScoped<IMenuBuilder, MenuBuilder>();


            // Add dummy data instead of getting data from api
            builder.Services.AddSingleton<IEncounterService, EncounterService>();
            builder.Services.AddSingleton<IHiredSwordService, DummyData>();
            builder.Services.AddHttpClient("HexedApi", client => 
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
            });


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
