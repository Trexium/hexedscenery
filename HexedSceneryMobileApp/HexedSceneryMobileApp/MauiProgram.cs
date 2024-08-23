using HexedSceneryData.Services;
using HexedSceneryMobileApp.Helpers;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

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
            builder.Services.AddSingleton<IEncounterService, DummyData>();
            builder.Services.AddSingleton<IGamePlayService, DummyData>();
            builder.Services.AddSingleton<IPostGameService, DummyData>();
            builder.Services.AddSingleton<IHiredSwordService, DummyData>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
