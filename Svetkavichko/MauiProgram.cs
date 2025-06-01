using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;
using Svetkavichko.Data;
using Svetkavichko.ViewModels;
using Svetkavichko.Views;

namespace Svetkavichko
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Gridtile-8Ojnz.ttf", "Gridtile");
                    fonts.AddFont("RubikBubbles-Regular.ttf", "RubikBubbles");
                });

            //vid
            builder.Services.AddDbContext<SvetkavichkoDbContext>();
            builder.Services.AddTransient<AddChorePage>();
            builder.Services.AddTransient<AddChoreViewModel>();
            builder.Services.AddTransient<ChorePage>();
            builder.Services.AddTransient<ChoreViewModel>();
            builder.Services.AddTransient<MusicPage>();
            var dbContext = new SvetkavichkoDbContext();
            //dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
