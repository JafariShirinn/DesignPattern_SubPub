using System;
using Domain.Models;
using Domain.Publisher;

namespace Domain.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IBroadcasting _broadcasting;

        public WeatherForecastService(IBroadcasting broadcasting)
        {
            _broadcasting = broadcasting;
        }
        public string Broadcast(WeatherForecastModel forecastModel)
        {
            if (forecastModel == null)
                throw new NullReferenceException(nameof(forecastModel));

            _broadcasting.NotifySubscribers(forecastModel);

            var xmlHelper = new XmlHelper();

            return xmlHelper.ReadForecast();
        }
    }
}
