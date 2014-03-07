using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TeamSoclApp
{
    public class weather
    {
        public string wx(string zip1)  // weather function to be implemented in full later - 90%
        {
            string answer = "";

            XmlDocument doc = new XmlDocument();
            doc.Load("http://xml.weather.yahoo.com/forecastrss?p=" + zip1);

            // Set up namespace manager for XPath  
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            // Get forecast with XPath  
            XmlNodeList nodes = doc.SelectNodes("/rss/channel/item/yweather:forecast", ns);

            try
            {
                answer = "Todays weather for " + zip1 + ": " + nodes[0].Attributes["day"].InnerText + ": " +
                    nodes[0].Attributes["text"].InnerText + ", " +
                    nodes[0].Attributes["low"].InnerText + "F - " +
                    nodes[0].Attributes["high"].InnerText + "F\n";
            }
            catch (Exception)
            {
                answer = "Weather service not currently available!";
            }
            return answer;
        }
    }
}
