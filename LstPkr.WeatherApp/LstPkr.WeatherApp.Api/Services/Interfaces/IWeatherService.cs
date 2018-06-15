using LstPkr.WeatherApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LstPkr.WeatherApp.Api.Services.Interfaces
{
    public interface IWeatherService
    {
        DailyForecast GetCurrentDay(string city);
        List<DailyForecast> GetForecast(string city);
    }
}
