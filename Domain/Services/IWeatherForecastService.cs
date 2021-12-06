using Domain.Models;

namespace Domain.Services
{
    public interface IWeatherForecastService
    {
        string Broadcast(WeatherForecastModel forecastModel);
    }
}
