using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LstPkr.WeatherApp.Api.Models;
using LstPkr.WeatherApp.Api.OpenWeatherApi;
using LstPkr.WeatherApp.Api.Services.DataAdapters;
using LstPkr.WeatherApp.Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LstPkr.WeatherApp.Api.Services.Implementations
{
    public class OpenWeatherService : IWeatherService
    {
        private readonly IConfiguration _configuration;
        private readonly OpenWeatherApiClient _apiClient;

        public OpenWeatherService(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiClient = new OpenWeatherApiClient(configuration);
        }
        public DailyForecast GetCurrentDay(string city)
        {
            var adapter = new OpenWeatherDataAdapter();
            var response = _apiClient.GetCurrentWeather(city);
            var currentDay = adapter.ParseData(response);
            return currentDay;
        }

        public List<DailyForecast> GetForecast(string city)
        {
            var adapter = new OpenWeatherDataAdapter();
            var response = _apiClient.GetForecast(city);
            var currentDay = adapter.ParseData(response);
            return currentDay;
        }
    }
}
