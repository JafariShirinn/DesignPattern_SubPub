using System;
using Domain.Mappers;
using Domain.Models;
using WebClient.Models;

namespace App.Mappers
{
    public class WeatherForecastRequestToWeatherForecastMapper :
        SimpleMapper<WeatherForecastRequestModel, WeatherForecastModel>
    {
        public override void Map(WeatherForecastRequestModel source, WeatherForecastModel target)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            target.Date = source.Date;
            target.Summary = GenerateSummary(source.Date, source.TemperatureInCelsius);
        }
 
        private static string GenerateSummary(DateTime forecastDate, int temperatureInCelsius)
        {
            return $"{forecastDate.ToShortDateString()} the temperature is {temperatureInCelsius}C/{ 32 + (int)(temperatureInCelsius / 0.5556)}F";
        }
    }
}
