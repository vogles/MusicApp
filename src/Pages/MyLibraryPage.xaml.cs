
using MusicApp.Models;
using MusicApp.ViewModels;
using Newtonsoft.Json;

namespace MusicApp;

public partial class MyLibraryPage : ContentPage
{
    public MyLibraryPage(MyLibraryViewModel viewModel)
    {
        InitializeComponent();
        
        BindingContext = viewModel;
    }

}