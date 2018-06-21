namespace WeatherForecast.Services.Models
{
    public class WeatherForecastResponse
    {
        public Location Location { get; set; }
        public Tempreature Tempreature { get; set; }
        public double Humidity { get; set; }
    }
}
