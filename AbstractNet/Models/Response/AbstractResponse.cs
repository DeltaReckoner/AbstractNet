using System.Text.Json.Serialization;

namespace AbstractNet
{
    public class AbstractResponse
    {
        [JsonPropertyName("original_size")]
        public int OriginalSize { get; set; }

        [JsonPropertyName("original_height")]
        public int OriginalHeight { get; set; }

        [JsonPropertyName("original_width")]
        public int OriginalWidth { get; set; }

        [JsonPropertyName("final_size")]
        public int FinalSize { get; set; }

        [JsonPropertyName("bytes_saved")]
        public int BytesSaved { get; set; }

        [JsonPropertyName("final_height")]
        public int FinalHeight { get; set; }

        [JsonPropertyName("final_width")]
        public int FinalWidth { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
