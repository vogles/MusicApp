using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.ViewModels;

namespace MusicApp.Pages;

public partial class ArtistDetailPage : ContentPage
{
    public ArtistDetailPage(ArtistDetailViewModel viewModel)
    {
        InitializeComponent();
        
        BindingContext = viewModel;
    }
}