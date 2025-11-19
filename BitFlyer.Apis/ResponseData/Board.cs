using System.Text.Json.Serialization;
using System.Text.Json;

namespace BitFlyer.Apis;

public class Board
{
    [JsonPropertyName("mid_price")]
    public double MiddlePrice { get; set; }

    [JsonPropertyName("asks")]
    public BoardOrder[]? Asks { get; set; }

    [JsonPropertyName("bids")]
    public BoardOrder[]? Bids { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

