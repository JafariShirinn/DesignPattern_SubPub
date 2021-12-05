using System.Collections.Generic;
using Domain.Media;
using Domain.Models;

namespace Domain.Publisher
{
    public class Broadcasting : IBroadcasting
    {
        private List<IBroadcastingSubscriber> _broadcastingSubscribers;

        public Broadcasting()
        {
            _broadcastingSubscribers = new List<IBroadcastingSubscriber>();
        }
        public void RegisterSubscriber(IBroadcastingSubscriber broadcastingSubscriber)
        {
            _broadcastingSubscribers.Add(broadcastingSubscriber);
        }

        public void UnRegisterSubscriber(IBroadcastingSubscriber broadcastingSubscriber)
        {
            _broadcastingSubscribers.Remove(broadcastingSubscriber);
        }

        public void NotifySubscribers(WeatherForecastModel weatherForecastModel)
        {
            foreach (var broadcastingSubscriber in _broadcastingSubscribers)
            {
                broadcastingSubscriber.Notify(weatherForecastModel);
            }
        }
    }
}
