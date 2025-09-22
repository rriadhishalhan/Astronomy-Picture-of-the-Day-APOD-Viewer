using System;

namespace Astronomy_Picture_of_the_Day_APOD_Viewer.Models;

public class ApodViewModel
{
    public DateTime Date { get; set; } = DateTime.Today;
    public ApodResponse? Photo { get; set; }
    public string? ErrorMessage { get; set; }

    public bool HasImage => Photo is { MediaType: var mediaType } && mediaType.Equals("image", StringComparison.OrdinalIgnoreCase);
}
