using LstPkr.WeatherApp.Api.Models;
using LstPkr.WeatherApp.Api.OpenWeatherApi.Current;
using LstPkr.WeatherApp.Api.OpenWeatherApi.Forecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LstPkr.WeatherApp.Api.Services.DataAdapters
{
    public class OpenWeatherDataAdapter
    {
        
        public DailyForecast ParseData(CurrentWeatherResponse data)
        {
            return new DailyForecast(data.Name, (int)data.Main.Temp, (int)data.Wind.Speed, (int)data.Main.Humidity, data.Dt);
        }

        public List<DailyForecast> ParseData(ForecastWeatherResponse data)
        {
            var dailyForecasts = new List<DailyForecast>();
            var days = data.List.GroupBy(g => UnixTimeStampToDateTime(g.Dt).Day);
            foreach (var day in days)
            {
                var tempAverage = day.Average(d => d.Main.Temp);
                var windSpeedAverage = day.Average(d => d.Wind.Speed);
                var humidityAverage = day.Average(d => d.Main.Humidity);
                var date = day.FirstOrDefault().Dt;
                dailyForecasts.Add(new DailyForecast(data.City.Name, (int)tempAverage, (int)windSpeedAverage, (int)humidityAverage, date));
            }

            return dailyForecasts;

        }

       

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
           
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
