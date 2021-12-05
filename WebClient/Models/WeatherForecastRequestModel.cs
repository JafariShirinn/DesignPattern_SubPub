using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class WeatherForecastRequestModel : IValidatableObject
    {
        public DateTime Date { get; set; }

        public int TemperatureInCelsius { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Date.Date < DateTime.UtcNow.Date)
                yield return new ValidationResult("Date should be today or later.");
        }
    }
}
