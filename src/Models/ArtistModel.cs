using Newtonsoft.Json;

namespace MusicApp.Models;

public class ArtistModel
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("coverArt")]
    public string CoverArt { get; set; }

    [JsonProperty("albumCount")]
    public int AlbumCount { get; set; }

    [JsonProperty("artistImageUrl")]
    public string ArtistImageUrl { get; set; }

    [JsonProperty("musicBrainzId")]
    public string MusicBranizId { get; set; }

    [JsonProperty("sortName")]
    public string SortName { get; set; }
}