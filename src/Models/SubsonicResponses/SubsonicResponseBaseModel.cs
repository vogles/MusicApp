using Newtonsoft.Json;

namespace MusicApp.Models.SubsonicResponses;

public class SubsonicResponseBaseModel
{
    [JsonProperty("status")] 
    public string Status { get; set; }

    [JsonProperty("version")] 
    public string Version { get; set; }

    [JsonProperty("type")] 
    public string Type { get; set; }

    [JsonProperty("serverVersion")] 
    public string ServerVersion { get; set; }

    [JsonProperty("openSubsonic")] 
    public string OpenSubsonic { get; set; }
}