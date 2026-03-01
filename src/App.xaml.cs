using MusicApp.Pages;

namespace MusicApp;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        // MainPage = new AppShell();
        MainPage = serviceProvider.GetService<LoginPage>();
    }
}