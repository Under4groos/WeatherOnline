using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherOnline
{
    
    public class Clouds
    {
        public int all { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    public class Root
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }


    public class n_Weather
    {
        
        public string City { get; set; }

        public Root GetWeather()
        {
            string http_ = $"http://api.openweathermap.org/data/2.5/weather?q={City}&lang=ru&units=metric&appid=fe57b721fd47b8600afac45a7829c1ea";
            Root myDeserializedClass = null;
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string json_ = webClient.DownloadString(http_);
                    myDeserializedClass = JsonConvert.DeserializeObject<Root>(json_);
                }
                catch {}
                
            }
            return myDeserializedClass;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            n_Weather Weather_ = new n_Weather()
            {
                City = "Moscow"
            };
            Root r = Weather_.GetWeather();
            if(r != null)
            {
                Console.WriteLine(r.wind.speed);
            }

            Console.ReadLine();


        }
    }
}
