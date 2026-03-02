using CommunityToolkit.Maui;
using MusicApp.Pages;
using MusicApp.Services;
using MusicApp.ViewModels;

namespace MusicApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .AddServices()
            .AddPages()
            .AddViewModels();

        return builder.Build();
    }

    private static MauiAppBuilder AddPages(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MyLibraryPage>();
        builder.Services.AddTransient<ArtistDetailPage>();
        
        return builder;
    }

    private static MauiAppBuilder AddServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IMusicService, NavidromeService>();
        
        return builder;
    }

    private static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MyLibraryViewModel>();
        builder.Services.AddTransient<ArtistDetailViewModel>();
        
        return builder;
    }
}