namespace WeatherForecast.Services.Models
{
    public class WeatherForecastResponse
    {
        public static readonly NullWeatherForecastResponse Null = new NullWeatherForecastResponse();
        public Location Location { get; set; }
        public Tempreature Tempreature { get; set; }
        public double Humidity { get; set; }
    }

    public class NullWeatherForecastResponse : WeatherForecastResponse
    {

    }
}
