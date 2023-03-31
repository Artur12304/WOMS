using Microsoft.AspNetCore.Mvc;
using RestApi.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace RestApi.WebApi.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Application.WeatherForecasts.Queries.GetWeatherForecasts.WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
