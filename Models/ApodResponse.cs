using System;
using System.Text.Json.Serialization;

namespace Astronomy_Picture_of_the_Day_APOD_Viewer.Models;

public class ApodResponse
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("explanation")]
    public string Explanation { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("media_type")]
    public string MediaType { get; set; } = string.Empty;

    [JsonPropertyName("hdurl")]
    public string? HdUrl { get; set; }
}
