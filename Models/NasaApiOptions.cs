namespace Astronomy_Picture_of_the_Day_APOD_Viewer.Models;

public class NasaApiOptions
{
    public const string SectionName = "NasaApi";

    public string BaseUrl { get; set; } = null!;

    public string ApiKey { get; set; } = null!;
}
