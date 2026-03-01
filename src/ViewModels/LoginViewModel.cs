
using System.Windows.Input;
using MusicApp.Services;

namespace MusicApp.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username = String.Empty;
    private string _password = String.Empty;
    private readonly IMusicService _musicService;
    private readonly IServiceProvider _serviceProvider;
    
    public string Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;

                OnPropertyChanged();
                (LoginSubmit as Command)?.ChangeCanExecute();
            }
        }
    }
    
    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;

                OnPropertyChanged();
                (LoginSubmit as Command)?.ChangeCanExecute();
            }
        }
    }

    public ICommand LoginSubmit { get; private set; }

    public LoginViewModel(IMusicService musicService, IServiceProvider serviceProvider)
    {
        _musicService = musicService;
        _serviceProvider = serviceProvider;
        
        LoginSubmit = new Command(OnLoginSubmit, CanLogin);
        
        TryAutoLogin();
    }

    private async void TryAutoLogin()
    {
        if (await _musicService.RetrieveCredentials())
        {
            Application.Current?.Windows[0].Page =
                new AppShell(); //new NavigationPage(_serviceProvider.GetService<MyLibraryPage>());
        }
    }

    private void OnLoginSubmit()
    {
        var loggedInSuccessfully = _musicService?.Authenticate(Username, Password).Result ?? false;

        if (loggedInSuccessfully)
        {
            Application.Current?.Windows[0].Page =
                new AppShell(); //new NavigationPage(_serviceProvider.GetService<MyLibraryPage>());
        }
    }

    private bool CanLogin()
    {
        return !(String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password));
    }
}