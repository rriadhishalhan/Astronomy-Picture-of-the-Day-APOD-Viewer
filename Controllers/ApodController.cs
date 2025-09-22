using System;
using System.Threading;
using System.Threading.Tasks;
using Astronomy_Picture_of_the_Day_APOD_Viewer.Models;
using Astronomy_Picture_of_the_Day_APOD_Viewer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Astronomy_Picture_of_the_Day_APOD_Viewer.Controllers;

public class ApodController : Controller
{
    private readonly IApodService _apodService;
    private readonly ILogger<ApodController> _logger;

    public ApodController(IApodService apodService, ILogger<ApodController> logger)
    {
        _apodService = apodService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Index(DateTime? date, CancellationToken cancellationToken)
    {
        var selectedDate = (date ?? DateTime.Today).Date;
        var viewModel = new ApodViewModel { Date = selectedDate };

        if (selectedDate > DateTime.Today)
        {
            viewModel.ErrorMessage = "Please choose a date that is not in the future.";
            return View(viewModel);
        }

        try
        {
            var apod = await _apodService.GetApodAsync(selectedDate, cancellationToken);
            viewModel.Photo = apod;

            if (apod is null)
            {
                viewModel.ErrorMessage = "We couldn't load the Astronomy Picture of the Day. Please try again later.";
            }
            else if (!viewModel.HasImage)
            {
                viewModel.ErrorMessage = "The APOD for this date is not an image. Try another date.";
            }
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to retrieve APOD data.");
            viewModel.ErrorMessage = "Something went wrong while reaching NASA. Please try again.";
        }

        return View(viewModel);
    }
}
