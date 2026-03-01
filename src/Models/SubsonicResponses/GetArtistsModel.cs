using Newtonsoft.Json;

namespace MusicApp.Models.SubsonicResponses;

public class GetArtistsModel
{
    [JsonProperty("index")]
    public List<ArtistIndexModel> Index { get; set; }

    [JsonProperty("ignoredArticles")]
    public string IgnoredArticles { get; set; }
}