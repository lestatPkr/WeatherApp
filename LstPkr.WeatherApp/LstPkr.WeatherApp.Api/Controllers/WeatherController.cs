using LstPkr.WeatherApp.Api.Models;
using LstPkr.WeatherApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LstPkr.WeatherApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWeatherService _weatherService;

        public WeatherController(IConfiguration configuration, IWeatherService weatherService)
        {
            _configuration = configuration;
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("current")]
        [Produces(typeof(DailyForecast))]
        public IActionResult GetCurrent(string city)
        {
            try
            {
                var response = _weatherService.GetCurrentDay(city);
                return Ok(response);
            }
            catch (ApplicationException ex)
            {

                return NotFound(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("forecast")]
        [Produces(typeof(List<DailyForecast>))]
        public IActionResult GetForecast(string city)
        {
            try
            {
                var response = _weatherService.GetForecast(city);
                return Ok(response);
            }
            catch (ApplicationException ex)
            {

                return NotFound(ex.Message);
            }

        }

    }
}
