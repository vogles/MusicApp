using Newtonsoft.Json;

namespace MusicApp.Models.SubsonicResponses;

public class GetArtistsResponseModel  : SubsonicResponseBaseModel
{
    [JsonProperty("artists")]
    public GetArtistsModel Artists { get; set; }
}