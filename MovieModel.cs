using System;
using System.Text.Json.Serialization;

namespace CS_FULLSTACK_27._11._2024;

public class MovieModel
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("year")]
    public int Year { get; set; }
    [JsonPropertyName("cast")]
    public List<string>? Cast { get; set; }
    [JsonPropertyName("genres")]
    public List<string>? Genres { get; set; }
    [JsonPropertyName("extract")]
    public string? Extract { get; set; }
}
