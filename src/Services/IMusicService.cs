using MusicApp.Models.SubsonicResponses;

namespace MusicApp.Services;

public interface IMusicService
{
    Task<bool> RetrieveCredentials();

    Task SaveCredentials(string creds);
    
    Task<bool> Authenticate(string username, string password);

    Task<List<ArtistIndexModel>> GetAllArtists();
}