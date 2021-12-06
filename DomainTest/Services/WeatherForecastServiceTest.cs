using Domain.Models;
using Domain.Publisher;
using Domain.Services;
using FizzWare.NBuilder;
using Moq;
using NUnit.Framework;
using System;
using FluentAssertions;

namespace DomainTest.Services
{
    [TestFixture]
    public class WeatherForecastServiceTests
    {
        private readonly Mock<IBroadcasting> _broadcastingMock = new();

        private IWeatherForecastService _service;

        [SetUp]
        public void Setup()
        {
            _service = new WeatherForecastService(_broadcastingMock.Object);
        }

        [Test]
        public void BroadcastAsync_modelIsNull_ShouldThrowNullReferenceException()
        {
            WeatherForecastModel weatherForecastModel = null;

            Func<string> action =  () => _service.Broadcast(weatherForecastModel);

            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void BroadcastAsync_OK_ShouldNotifyAllMedia()
        {
            var weatherForecastModel = Builder<WeatherForecastModel>
                .CreateNew()
                .With(model => model.Date, DateTime.UtcNow)
                .With(model => model.Summary, "Today the temperature is  32C")
                .Build();

            var result = _service.Broadcast(weatherForecastModel);

            result.Should().NotBeNull();
            _broadcastingMock.Verify(x => x.NotifySubscribers(weatherForecastModel), Times.Once);
        }
    }
}