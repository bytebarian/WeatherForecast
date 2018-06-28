using WeatherForecast.Services.Services;
using Xunit;
using System;

namespace WeatherForecast.IntegrationTests
{
    public class OpenWeatherMapApiTests
    {
        [Fact]
        public void TempratreAndHumidityTest()
        {
            var service = new OpenWeatherMapService();
            var response = service.GetWeatherForecastAsync(new Services.Models.WeatherForecastRequest
            {
                Configuration = new Services.Models.ApiConfiguration
                {
                    ApiKey = "ffa42a7152fe42b4afb5139e65b3c6d7"
                },
                Location = new Services.Models.Location
                {
                    City = "London",
                    Country = "United Kingdom"
                }
            }).Result;

            Assert.NotNull(response);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.Tempreature);
            Assert.Equal("london", response.Location.City.ToLower());
            Assert.Equal("united kingdom", response.Location.Country.ToLower());
            Assert.Equal("celsius", response.Tempreature.Format.ToLower());
            Assert.NotEqual(0, response.Tempreature.Value);
            Assert.NotEqual(0, response.Humidity);

        }
    }
}
