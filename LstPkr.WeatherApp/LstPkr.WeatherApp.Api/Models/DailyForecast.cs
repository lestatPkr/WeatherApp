using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LstPkr.WeatherApp.Api.Models
{
    public class DailyForecast
    {
        [JsonProperty("city")]
        public string City { get; private set; }
        [JsonProperty("temperature")]
        public int Temperature { get; private set; }
        [JsonProperty("windSpeed")]
        public int WindSpeed { get; private set; }
        [JsonProperty("humidity")]
        public int Humidity { get; private set; }
        [JsonProperty("weatherId")]
        public int WeatherId { get; private set; }
        [JsonProperty("date")]
        public DateTime Date { get; private set; }

        public DailyForecast(string city, int temperature, int windSpeed, 
        int humidity, int weatherId, DateTime date)
        {
            City = city;
            Temperature = temperature;
            WindSpeed = windSpeed;
            Humidity = humidity;
            WeatherId = weatherId;
            Date = date;
        }

    }
}
