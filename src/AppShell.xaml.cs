using MusicApp.Pages;

namespace MusicApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(MyLibraryPage), typeof(MyLibraryPage));
        Routing.RegisterRoute(nameof(ArtistDetailPage), typeof(ArtistDetailPage));
    }
}