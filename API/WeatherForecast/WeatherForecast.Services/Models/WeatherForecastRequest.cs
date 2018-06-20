using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Services.Models
{
    public class WeatherForecastRequest
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
