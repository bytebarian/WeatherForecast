using WeatherForecast.Services.Services;
using Xunit;

namespace WeatherForecast.AcceptanceTests
{
    public class AcceptanceTests
    {
        [Fact]
        public void AcceptancePolandWarsawTest()
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
                    City = "Warsaw",
                    Country = "Poland"
                }
            }).Result;

            Assert.NotNull(response);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.Tempreature);
            Assert.Equal("warsaw", response.Location.City.ToLower());
            Assert.Equal("poland", response.Location.Country.ToLower());
            Assert.Equal("celsius", response.Tempreature.Format.ToLower());
            Assert.NotEqual(0, response.Tempreature.Value);
            Assert.NotEqual(0, response.Humidity);

        }

        [Fact]
        public void AcceptancePolandGdanskTest()
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
                    City = "Gdansk",
                    Country = "Poland"
                }
            }).Result;

            Assert.NotNull(response);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.Tempreature);
            Assert.Equal("gdansk", response.Location.City.ToLower());
            Assert.Equal("poland", response.Location.Country.ToLower());
            Assert.Equal("celsius", response.Tempreature.Format.ToLower());
            Assert.NotEqual(0, response.Tempreature.Value);
            Assert.NotEqual(0, response.Humidity);

        }

        [Fact]
        public void AcceptancegermanBerlinTest()
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
                    City = "Berlin",
                    Country = "German"
                }
            }).Result;

            Assert.NotNull(response);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.Tempreature);
            Assert.Equal("berlin", response.Location.City.ToLower());
            Assert.Equal("german", response.Location.Country.ToLower());
            Assert.Equal("celsius", response.Tempreature.Format.ToLower());
            Assert.NotEqual(0, response.Tempreature.Value);
            Assert.NotEqual(0, response.Humidity);

        }
    }
}
