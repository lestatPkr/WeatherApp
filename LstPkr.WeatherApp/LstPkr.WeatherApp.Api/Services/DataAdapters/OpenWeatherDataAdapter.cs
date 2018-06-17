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
            return new DailyForecast(data.Name, (int)data.Main.Temp, 
            (int)data.Wind.Speed, (int)data.Main.Humidity, 
            Convert.ToInt32(data.Weather.FirstOrDefault()?.Id.ToString().Substring(0,1)) 
            ,UnixTimeStampToDateTime(data.Dt));
        }

        public List<DailyForecast> ParseData(ForecastWeatherResponse data)
        {
            var dailyForecasts = new List<DailyForecast>();
            var days = data.List.GroupBy(g => UnixTimeStampToDateTime(g.Dt).Day);
            foreach (var day in days)
            {
                var tempAverage = (int)day.Average(d => d.Main.Temp);
                var windSpeedAverage = (int)day.Average(d => d.Wind.Speed);
                var humidityAverage = (int)day.Average(d => d.Main.Humidity);
                var date = UnixTimeStampToDateTime(day.FirstOrDefault().Dt);
                var weatherId = GetWeatherId((long)day.FirstOrDefault().Weather.FirstOrDefault()?.Id);
                dailyForecasts.Add(new DailyForecast(data.City.Name, tempAverage,
                windSpeedAverage, humidityAverage, weatherId, date));
            }

            return dailyForecasts;

        }

        private int GetWeatherId(long id){
            var stringId = id.ToString().Substring(0,1);
            if(stringId == "8"){
                return id == 800 ? 8 : 7;
            }
            return Convert.ToInt32(stringId);
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
