using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;

#if IOS
using BaseUrlBugDemo.Platforms.iOS.CustomWebView;
#endif


namespace BaseUrlBugDemo;
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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureMauiHandlers((handlers) =>
            {
#if IOS
                // https://blog.jhonatanoliveira.dev/customize-controls-with-handlers-with-net-maui
                // https://github.com/dotnet/maui/wiki/Customizing-Controls-with-Handlers
                // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/handlers/customize?view=net-maui-8.0
                // -
                handlers.AddHandler(typeof(WebView), typeof(CustomWebViewHandler));
#endif
            });



#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

