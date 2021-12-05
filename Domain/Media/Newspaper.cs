using Domain.Models;
using Domain.Publisher;

namespace Domain.Media
{
    public class Newspaper : INewspaper, IBroadcastingSubscriber
    {
        public Newspaper(IBroadcasting broadcasting)
        {
            broadcasting.RegisterSubscriber(this);
        }
   
        public void Notify(WeatherForecastModel weatherForecastModel)
        {
            var xmlHelper = new XmlHelper();
            xmlHelper.UpdateForecast("Newspaper", weatherForecastModel);
        }
    }
}
