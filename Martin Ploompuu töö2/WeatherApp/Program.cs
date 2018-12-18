using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DownloadXML();
            Console.ReadKey();
        
        }

        static async void DownloadXML()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://www.yr.no/place/Estonia/Harjumaa/Tallinn/forecast.xml");
            var content = response.Content;
            string result = await content.ReadAsStringAsync();
            XElement root = XElement.Parse(result);

           var location = root.Element("location");

            Console.WriteLine("{0},{1}", location.Element("name").Value, location.Element("country").Value);

            var forecast = root.Element("forecast").Elements("tabular").Elements("time");
            foreach(var item in forecast)
            {
                DateTime date = DateTime.Parse(item.Attribute("from").Value);
                date.ToString("dd/MM HH:mm");
                Console.WriteLine("{3} {4,2}:00 {2,3}*{1} {0}",
                    item.Element("symbol").Attribute("name").Value,
                    item.Element("temperature").Attribute("unit").Value.Substring(0, 1).ToUpper(),
                    item.Element("temperature").Attribute("value").Value,
                    date.DayOfWeek.ToString().Substring(0, 1),
                    date.Hour);
                
            }
        }
    }
}
