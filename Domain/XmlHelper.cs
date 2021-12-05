using System.IO;
using System.Threading.Tasks;
using System.Xml;
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
            var document = new XDocument();

            if (!File.Exists(_xmlPath))
                CreateXml();


            document = XDocument.Load(_xmlPath);

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

        public string ReadForecast()
        {
            if (!File.Exists(_xmlPath))
                CreateXml();

            var document = XDocument.Load(_xmlPath);

            return JsonConvert.SerializeXNode(document);
        }

        private void CreateXml()
        {
            var document = new XDocument(new XElement("Forecast", ""));
            document.Save(_xmlPath);
        }
    }
}
