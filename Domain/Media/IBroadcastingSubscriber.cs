using Domain.Models;

namespace Domain.Media
{
    public interface IBroadcastingSubscriber
    {
        void Notify(WeatherForecastModel weatherForecastModel);
    }
}
