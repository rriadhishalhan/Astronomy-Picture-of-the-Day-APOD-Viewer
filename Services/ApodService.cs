using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Astronomy_Picture_of_the_Day_APOD_Viewer.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Astronomy_Picture_of_the_Day_APOD_Viewer.Services;

public class ApodService : IApodService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApodService> _logger;
    private readonly NasaApiOptions _options;

    public ApodService(HttpClient httpClient, IOptions<NasaApiOptions> options, ILogger<ApodService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<ApodResponse?> GetApodAsync(DateTime date, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, string?>
        {
            ["api_key"] = string.IsNullOrWhiteSpace(_options.ApiKey) ? "DEMO_KEY" : _options.ApiKey,
            ["date"] = date.ToString("yyyy-MM-dd")
        };

        var requestUri = QueryHelpers.AddQueryString(string.Empty, query);

        try
        {
            using var response = await _httpClient.GetAsync(requestUri, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return await JsonSerializer.DeserializeAsync<ApodResponse>(stream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }, cancellationToken);
            }

            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogWarning("APOD request failed with {StatusCode}: {Body}", response.StatusCode, body);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error while fetching APOD data.");
        }

        return null;
    }
}
