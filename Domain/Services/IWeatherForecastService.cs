using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IWeatherForecastService
    {
        Task<string> BroadcastAsync(WeatherForecastModel forecastModel);
    }
}
