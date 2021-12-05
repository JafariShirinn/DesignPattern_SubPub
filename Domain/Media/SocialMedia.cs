using Domain.Models;
using Domain.Publisher;

namespace Domain.Media
{
    public class SocialMedia : ISocialMedia, IBroadcastingSubscriber
    {

        public SocialMedia(IBroadcasting broadcasting)
        {
            broadcasting.RegisterSubscriber(this);
        }

        public void Notify(WeatherForecastModel weatherForecastModel)
        {
            var xmlHelper = new XmlHelper();
            xmlHelper.UpdateForecast("SocialMedia", weatherForecastModel);
        }
    }
}
