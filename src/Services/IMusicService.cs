using MusicApp.Models;

namespace MusicApp.Services;

public interface IMusicService
{
    Task<bool> RetrieveCredentials();

    Task SaveCredentials(string creds);
    
    Task<bool> Authenticate(string username, string password);

    Task<List<ArtistModel>> GetAllArtists();

    Task<Stream> GetCoverArtStream(string coverArtId, int? size);
}