using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using BudgetAnalyzer.Shared.State;

namespace BudgetAnalyzer
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

            // State Management
            builder.Services.AddSingleton<StateManager>();

            #if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }
    }
}
