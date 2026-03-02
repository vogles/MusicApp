using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicApp.Models;

namespace MusicApp.ViewModels;

[QueryProperty("Artist", "model")]
public partial class ArtistDetailViewModel : ObservableObject
{
    [ObservableProperty]
    private ArtistModel _artist;

    [RelayCommand]
    async Task OnGoBack()
    {
        await Shell.Current.GoToAsync("..");
        
    }
}