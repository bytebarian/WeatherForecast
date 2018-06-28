using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherForecast.Models;
using WeatherForecast.Services.Interfaces;
using WeatherForecast.Services.Models;

namespace WeatherForecast.Controllers
{
    [RoutePrefix("api/weather")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Method for getting weather forecast
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{country}/{city}")]
        [ResponseType(typeof(WeatherForecastModel))]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetWeatherForecastAsync(string country, string city)
        {
            var response = await _weatherService.GetWeatherForecastAsync(new WeatherForecastRequest
            {
                Location = new Location
                {
                    City = city,
                    Country = country
                },
                Configuration = new ApiConfiguration
                {
                    ApiKey = ConfigurationManager.AppSettings["OpenWeatherMapApiKey"]
                }
            });
            if(response != null && !(response is NullWeatherForecastResponse))
            {
                return Ok(WeatherForecastModelConverter.Convert(response));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
