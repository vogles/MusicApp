using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text;
using MusicApp.Models;
using MusicApp.Models.SubsonicResponses;
using Newtonsoft.Json;

namespace MusicApp.Services;

public class NavidromeService : IMusicService
{
    private HttpClient _client;
    private UserModel _user;

    public NavidromeService()
    {
        var socketsHandler = new SocketsHttpHandler()
        {
            PooledConnectionIdleTimeout =  TimeSpan.FromMinutes(2),
        };
        
        _client = new HttpClient(socketsHandler)
        {
            BaseAddress =  new Uri("https://music.rojolabs.net/"),
            Timeout =  TimeSpan.FromSeconds(10)
        };
    }

    public async Task<bool> RetrieveCredentials()
    {
        var userJson = await SecureStorage.Default.GetAsync("navidrome_user");
        if (String.IsNullOrEmpty(userJson))
            return false;
        
        var user = JsonConvert.DeserializeObject<UserModel>(userJson);

        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/keepalive/keepalive"))
        {
            requestMessage.Headers.Add("x-nd-authorization", $"Bearer {user.Token}");
            requestMessage.Headers.Add("x-nd-client-unique-id", user.Id);
            
            var responseMessage = await _client.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                return false;

            var content = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }

        _user = user;
        
        return true;
    }

    public async Task SaveCredentials(string creds)
    {
        await SecureStorage.Default.SetAsync("navidrome_user", creds);
    }
    
    public async Task<bool> Authenticate(string username, string password)
    {
        var data = new Dictionary<string, string>()
        {
            {"username", username},
            {"password", password}
        };
        
        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        HttpResponseMessage response = null;
        
        try
        {
            response = _client.PostAsync("auth/login", new StringContent(jsonString)).Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        bool loginSuccessful = response.IsSuccessStatusCode;
        if (loginSuccessful)
        {
            var content = await response.Content.ReadAsStringAsync();
            
            _user = JsonConvert.DeserializeObject<UserModel>(content);

            await SaveCredentials(content);
        }

        return loginSuccessful;
    }

    public async Task<List<ArtistIndexModel>> GetAllArtists()
    {
        // string content = String.Empty;
        //
        // using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/artist"))
        // {
        //     requestMessage.Headers.Add("x-nd-authorization", $"Bearer {_user.Token}");
        //     requestMessage.Headers.Add("x-nd-client-unique-id", _user.Id);
        //     
        //     var responseMessage = await _client.SendAsync(requestMessage);
        //
        //     if (!responseMessage.IsSuccessStatusCode)
        //         return new List<ArtistIndexModel>();
        //
        //     content = await responseMessage.Content.ReadAsStringAsync();
        //     Console.WriteLine(content);
        // }
        
        HttpResponseMessage response = null;
        var uriBuilder = new StringBuilder();
        uriBuilder.Append("rest/getArtists");
        uriBuilder.Append("?v=").Append(Uri.EscapeDataString("1.16.1"));
        uriBuilder.Append("&c=").Append(Uri.EscapeDataString("com.vogles.musicapp"));
        uriBuilder.Append("&u=").Append(Uri.EscapeDataString(_user.Username));
        uriBuilder.Append("&s=").Append(Uri.EscapeDataString(_user.SubsonicSalt));
        uriBuilder.Append("&t=").Append(Uri.EscapeDataString(_user.SubsonicToken));
        uriBuilder.Append("&f=").Append("json");
        
        response = await _client.GetAsync(uriBuilder.ToString());
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Dictionary<string, GetArtistsResponseModel>>(content);
        return result["subsonic-response"].Artists.Index;
    }
}