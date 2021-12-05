using Domain.Media;
using Domain.Models;

namespace Domain.Publisher
{
    public interface IBroadcasting
    {
        void RegisterSubscriber(IBroadcastingSubscriber broadcastingSubscriber);
        void UnRegisterSubscriber(IBroadcastingSubscriber broadcastingSubscriber);
        void NotifySubscribers(WeatherForecastModel weatherForecastModel);
    }
}
