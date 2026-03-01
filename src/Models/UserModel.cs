
using Newtonsoft.Json;

namespace MusicApp.Models;

public class UserModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("isAdmin")]
    public bool IsAdmin { get; set; }
    
    [JsonProperty("subsonicSalt")]
    public string SubsonicSalt { get; set; }
    
    [JsonProperty("subsonicToken")]
    public string SubsonicToken { get; set; }
    
    [JsonProperty("token")]
    public string Token { get; set; }
}