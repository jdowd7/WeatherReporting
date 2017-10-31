using FluentAssertions;
using WeatherReporting.Domain.Model;
using WeatherReporting.Orchestration.Interface;
using WeatherReporting.Orchestration.Service;
using WeatherReportingTest.Infrastucture;
using Xunit;

namespace WeatherReportingTest.Integration.Orchestration.Service
{
  public class WeatherServiceTest : TestContainer
  {

    public IWeatherService WeatherService { get; set; }

    public WeatherServiceTest()
    {
      WeatherService = Container.GetInstance<WeatherService>();
    }


    [Fact]
    public void AggregateWeatherData_ValidSingleInputGiven_ShouldReturnSingleOutput()
    {
      // Arrange
      var dataPointValid = new WeatherData
      {
        City = "Boulder",
        State = "Colorado",
        HighTemp = 80,
        LowTemp = 45
      };

      // Act
      var result = WeatherService.AggregateWeatherData(new[] { dataPointValid });

      // Assert
      result.Should().ContainSingle();
    }

    [Theory]
    [InlineData(1)]
    public void TestMethod2(int one)
    {
    }
  }
}
