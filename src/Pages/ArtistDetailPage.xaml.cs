using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MusicApp.ViewModels;

namespace MusicApp.Pages;

[QueryProperty("Artist", "model")]
public partial class ArtistDetailPage : ContentPage
{
    public ArtistDetailPage(ArtistDetailViewModel viewModel)
    {
        InitializeComponent();
        
        BindingContext = viewModel;
    }
}