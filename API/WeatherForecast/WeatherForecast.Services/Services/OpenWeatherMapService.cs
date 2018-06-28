using System;
using NLog;
using OpenWeatherMap;
using WeatherForecast.Services.Interfaces;
using WeatherForecast.Services.Models;

namespace WeatherForecast.Services.Services
{
    public class OpenWeatherMapService : IWeatherService
    {
        public OpenWeatherMapService()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;
        }

        public async System.Threading.Tasks.Task<WeatherForecastResponse> GetWeatherForecastAsync(WeatherForecastRequest request)
        {
            if(request == null)
            {
                throw new ArgumentNullException("request object is null");
            }
            if(request.Configuration == null)
            {
                throw new ArgumentNullException("configuration object is null");
            }
            if (string.IsNullOrEmpty(request.Configuration.ApiKey))
            {
                throw new ArgumentException("Api key is missing");
            }
            if(request.Location == null)
            {
                throw new ArgumentNullException("Location object is null");
            }
            if (string.IsNullOrEmpty(request.Location.City))
            {
                throw new ArgumentException("Location city is missing");
            }
            var client = new OpenWeatherMapClient(request.Configuration.ApiKey);
            try
            {
                var currentWeather = await client.CurrentWeather.GetByName(request.Location.City, MetricSystem.Metric);
                return ConvertToServiceModel(currentWeather, request);
            }
            catch(Exception ex)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex);
                return WeatherForecastResponse.Null;
            }           
        }

        private WeatherForecastResponse ConvertToServiceModel(CurrentWeatherResponse currentWeather, WeatherForecastRequest request)
        {
            return new WeatherForecastResponse
            {
                Location = request.Location,
                Tempreature = new Tempreature
                {
                    Format = "Celsius",
                    Value = currentWeather.Temperature.Value
                },
                Humidity = currentWeather.Humidity.Value
            };
        }
    }
}
