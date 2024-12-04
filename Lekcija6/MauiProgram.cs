using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Lekcija6
{
    public static class MauiProgram
    {
        public static IConfiguration Configuration { get; private set; }
        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

           // Configuration = new ConfigurationBuilder()
           //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           //.Build();

            builder.Configuration.AddConfiguration(Configuration);

            builder.Services.AddSingleton<IConfiguration>(Configuration);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
