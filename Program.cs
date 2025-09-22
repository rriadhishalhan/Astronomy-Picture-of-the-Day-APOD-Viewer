using Astronomy_Picture_of_the_Day_APOD_Viewer.Models;
using Astronomy_Picture_of_the_Day_APOD_Viewer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<NasaApiOptions>(builder.Configuration.GetSection(NasaApiOptions.SectionName));

builder.Services.AddHttpClient<IApodService, ApodService>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<NasaApiOptions>>().Value;
    client.BaseAddress = new Uri(options.BaseUrl);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Apod/Index");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Apod}/{action=Index}/{id?}");

app.Run();
