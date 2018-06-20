using WeatherForecast.Services.Models;

namespace WeatherForecast.Services.Interfaces
{
    public interface IWeatherService
    {
        WeatherForecastResponse GetWeatherForecast(WeatherForecastRequest request);
    }
}
