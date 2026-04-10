
using Microsoft.Extensions.Logging;

#region additional namespaces
using MauiAppDemo.Services;
#endregion

namespace MauiAppDemo
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

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            //add the required code so to be able to inject the services via
            //  the interface into the app

            builder.Services.AddSingleton<IProductServices,MockProductServices>();
            builder.Services.AddSingleton<IUtilitiesServices, UtilitiesServices>();
            builder.Services.AddSingleton<IPreferenceServices, PreferenceServices>();

            return builder.Build();
        }
    }
}
