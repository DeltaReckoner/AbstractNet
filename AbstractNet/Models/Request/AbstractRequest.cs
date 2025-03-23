using System.Text.Json.Serialization;

namespace AbstractNet
{
    public class AbstractRequest
    {
        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; } = null;

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("lossy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Lossy { get; set; } = null;

        [JsonPropertyName("quality")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Quality { get; set; } = null;

        [JsonPropertyName("resize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResizeOptions ResizeOptions { get; set; } = null;
    }
}
