//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radzen;
//using Windows.UI;

namespace ControlGP
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

            //// Configuración de Entity Framework con DbContextFactory
            //builder.Services.AddDbContextFactory<dbContext>(options =>
            //    options.UseSqlServer("Server=69.197.174.111,1460\\DEV2022;Database=Facturacion;User Id=univalle;Password=#Univalle#123;TrustServerCertificate=True;"));

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddRadzenComponents();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
