using Domain.Models;
using Domain.Publisher;

namespace Domain.Media
{
    public class RadioStation : IRadioStation, IBroadcastingSubscriber
    {
        public RadioStation(IBroadcasting broadcasting)
        {
            broadcasting.RegisterSubscriber(this);
        }

        public void Notify(WeatherForecastModel weatherForecastModel)
        {
            var xmlHelper = new XmlHelper();
            xmlHelper.UpdateForecast("RadioStation", weatherForecastModel);
        }
    }
}
