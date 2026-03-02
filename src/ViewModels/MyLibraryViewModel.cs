using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicApp.Models;
using MusicApp.Pages;
using MusicApp.Services;

namespace MusicApp.ViewModels;

public partial class MyLibraryViewModel : ObservableObject
{
    private readonly IMusicService _musicService;
    
    [ObservableProperty]
    private ObservableCollection<ArtistModel> _artists = new ObservableCollection<ArtistModel>();
    
    // public IAsyncRelayCommand ArtistSelectedCommand { get; }

    // public ObservableCollection<ArtistModel> Artists => _artists;
    
    public MyLibraryViewModel(IMusicService musicService)
    {
        _musicService = musicService;
        
        FetchArtists();
    }

    private async void FetchArtists()
    {
        var artists = await _musicService.GetAllArtists();

        artists.ForEach(a => Artists.Add(a));
    }

    [RelayCommand]
    private async Task OnArtistSelected(ArtistModel artist)
    {
        await Shell.Current.GoToAsync(nameof(ArtistDetailPage),
            new Dictionary<string, object>()
            {
                {"model", artist}
            });
    }
}