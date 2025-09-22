using System;
using System.Threading;
using System.Threading.Tasks;
using Astronomy_Picture_of_the_Day_APOD_Viewer.Models;

namespace Astronomy_Picture_of_the_Day_APOD_Viewer.Services;

public interface IApodService
{
    Task<ApodResponse?> GetApodAsync(DateTime date, CancellationToken cancellationToken = default);
}
