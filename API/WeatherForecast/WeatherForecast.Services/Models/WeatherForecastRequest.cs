namespace WeatherForecast.Services.Models
{
    public class WeatherForecastRequest
    {
        public Location Location { get; set; }
        public ApiConfiguration Configuration { get; set; }
    }

    public class ApiConfiguration
    {
        public string ApiKey { get; set; }
    }
}
