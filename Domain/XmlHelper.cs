using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Models;
using Newtonsoft.Json;

namespace Domain
{
    public class XmlHelper
    {
        private readonly string _xmlPath = $"{System.AppDomain.CurrentDomain.BaseDirectory}File\\ForecastResults.xml";

        public void UpdateForecast(string media, WeatherForecastModel weatherForecastModel)
        {
            var document = XDocument.Load(_xmlPath);
            var root = document.Element("Forecast");

            var currentElement = document.Element(media);

            if (currentElement == null)
            {
                root.Add(new XElement(media, new XElement("Summary", weatherForecastModel.Summary)));
            }
            else
            {
                currentElement.Add(new XElement("Summary", weatherForecastModel.Summary));
            }

            document.Save(_xmlPath);
        }

        public async Task<string> ReadForecastAsync()
        {
            var document = XDocument.Load(_xmlPath);

            return JsonConvert.SerializeXNode(document);

        }
    }
}
