using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LstPkr.WeatherApp.Api.OpenWeatherApi.Current;
using LstPkr.WeatherApp.Api.OpenWeatherApi.Forecast;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace LstPkr.WeatherApp.Api.OpenWeatherApi
{
    public class OpenWeatherApiClient : BaseApiClient
    {
        public OpenWeatherApiClient(IConfiguration configuration) 
            : base(configuration)
        {


        }

        public CurrentWeatherResponse GetCurrentWeather(string city)
        {
            var request = GetNewRequest($"/weather?q={city}");
            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;
            var response = Execute<CurrentWeatherResponse>(request);
            var result = response.Data;
            return result;
        }

        public ForecastWeatherResponse GetForecast(string city)
        {
            var request = GetNewRequest($"/forecast?q={city}");
            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;
            var response = Execute<ForecastWeatherResponse>(request);
            var result = response.Data;
            return result;
        }
    }
}
