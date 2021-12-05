using System;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Publisher;

namespace Domain.Services
{
    public class WeatherForecastService: IWeatherForecastService
    {
        private readonly IBroadcasting _broadcasting;

        public WeatherForecastService(IBroadcasting broadcasting)
        {
            _broadcasting = broadcasting;
        }
        public async Task<string> BroadcastAsync(WeatherForecastModel forecastModel)
        {
            if (forecastModel == null)
                throw new NullReferenceException(nameof(forecastModel));

            _broadcasting.NotifySubscribers(forecastModel);

            var xmlHelper = new XmlHelper();

            return await xmlHelper.ReadForecastAsync();
        }
    }
}
