using Newtonsoft.Json;

namespace MusicApp.Models.SubsonicResponses;

public class ArtistIndexModel
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("artist")]
    public List<ArtistModel> Artist { get; set; }
}