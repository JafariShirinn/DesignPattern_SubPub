using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IWeatherForecastService
    {
        string Broadcast(WeatherForecastModel forecastModel);
    }
}
