using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;
using Xunit;

namespace WeatherForecast.UnitTests
{
    public class ModelMapperTests
    {
        [Fact]
        public void ModelMappingTest()
        {
            var response = WeatherForecastModelConverter.Convert(new Services.Models.WeatherForecastResponse
            {
                Humidity = 39.6,
                Location = new Services.Models.Location
                {
                    City = "Warsaw",
                    Country = "Poland"
                },
                Tempreature = new Services.Models.Tempreature
                {
                    Format = "Celsius",
                    Value = 22.1
                }
            });
            Assert.NotNull(response);
            Assert.NotNull(response.Location);
            Assert.NotNull(response.Tempreature);
            Assert.Equal(39.6, response.Humidity);
            Assert.Equal("warsaw", response.Location.City.ToLower());
            Assert.Equal("poland", response.Location.Country.ToLower());
            Assert.Equal("celsius", response.Tempreature.Format.ToLower());
            Assert.Equal(22.1, response.Tempreature.Value);
        }
    }
}
