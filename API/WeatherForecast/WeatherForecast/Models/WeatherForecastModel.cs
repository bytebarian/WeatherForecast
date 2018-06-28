using System;
using WeatherForecast.Services.Models;

namespace WeatherForecast.Models
{
    public class WeatherForecastModel
    {
        public LocationModel Location { get; set; }
        public TempreatureModel Tempreature { get; set; }
        public double Humidity { get; set; }
    }

    public class LocationModel
    {
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class TempreatureModel
    {
        public string Format { get; set; }
        public double Value { get; set; }
    }

    public static class WeatherForecastModelConverter
    {
        public static WeatherForecastModel Convert(WeatherForecastResponse requestObject)
        {
            if(requestObject == null)
            {
                throw new ArgumentNullException();
            }
            return new WeatherForecastModel
            {
                Location = new LocationModel
                {
                    City = requestObject.Location.City,
                    Country = requestObject.Location.Country
                },
                Tempreature = new TempreatureModel
                {
                    Format = requestObject.Tempreature.Format,
                    Value = requestObject.Tempreature.Value
                },
                Humidity = requestObject.Humidity
            };
        }
    }
}