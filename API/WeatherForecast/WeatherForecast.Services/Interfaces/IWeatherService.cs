using System.Threading.Tasks;
using WeatherForecast.Services.Models;

namespace WeatherForecast.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherForecastResponse> GetWeatherForecastAsync(WeatherForecastRequest request);
    }
}
