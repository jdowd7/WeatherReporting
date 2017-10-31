using System;
using System.Collections;
using System.Collections.Generic;
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
        Date = DateTime.UtcNow,
        HighTemp = 80,
        LowTemp = 45
      };

      // Act
      var result = WeatherService.AggregateWeatherData(new[] { dataPointValid });

      // Assert
      result.Should().ContainSingle();
    }

    [Fact]
    public void AggregateWeatherData_InvalidSingleInputGiven_ShouldReturnEmptyOutput()
    {
      // Arrange
      var dataPointValid = new WeatherData
      {
        City = "Boulder",
        State = "Not Colorado",
        Date = DateTime.UtcNow,
        HighTemp = 80,
        LowTemp = 45
      };

      // Act
      var result = WeatherService.AggregateWeatherData(new[] { dataPointValid });

      // Assert
      result.Should().BeEmpty();
    }

    [Fact]
    public void AggregateWeatherData_ValidTwelveInputsGiven_ShouldReturnFiveOutputs()
    {
      // Arrange - Need to implement ClassData or PropertyData
      var validDataPointList = new List<WeatherData>
      {
        new WeatherData
        {
          City = "CityExample1",
          State = "Colorado",
          Date = DateTime.UtcNow,
          HighTemp = 80,
          LowTemp = 60
        },
        new WeatherData
        {
          City = "CityExample1",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-1),
          HighTemp = 80,
          LowTemp = 60
        },
        new WeatherData
        {
          City = "CityExample1",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-2),
          HighTemp = 60,
          LowTemp = 30
        },
        new WeatherData
        {
          City = "CityExample1",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-4),
          HighTemp = 70,
          LowTemp = 50
        },
        new WeatherData {City = "CityExample2", State = "Alabama", Date = DateTime.UtcNow, HighTemp = 70, LowTemp = 60},
        new WeatherData
        {
          City = "CityExample2",
          State = "Alabama",
          Date = DateTime.UtcNow.AddDays(-1),
          HighTemp = 70,
          LowTemp = 50
        },
        new WeatherData
        {
          City = "CityExample2",
          State = "Alabama",
          Date = DateTime.UtcNow.AddDays(-2),
          HighTemp = 70,
          LowTemp = 55
        },
        new WeatherData
        {
          City = "CityExample3",
          State = "New York",
          Date = DateTime.UtcNow,
          HighTemp = 80,
          LowTemp = 60
        },
        new WeatherData {City = "CityExample4", State = "Florida", Date = DateTime.UtcNow, HighTemp = 80, LowTemp = 60},
        new WeatherData
        {
          City = "CityExample5",
          State = "Colorado",
          Date = DateTime.UtcNow,
          HighTemp = 80,
          LowTemp = 60
        },
        new WeatherData
        {
          City = "CityExample5",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-1),
          HighTemp = 70,
          LowTemp = 50
        },
        new WeatherData
        {
          City = "CityExample5",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-2),
          HighTemp = 60,
          LowTemp = 40
        }

      };

      // Act
      var result = WeatherService.AggregateWeatherData(validDataPointList.ToArray());

      // Assert
      result.Should().HaveCount(5);
    }

    [Fact] //TODO: FINISH
    public void AggregateWeatherData_InvalidTwelveInputsGiven_ShouldContainInvalidState()
    {
      // Arrange - Need to implement ClassData or PropertyData
      var validDataPointList = new List<WeatherData>
      {
        new WeatherData
        {
          City = "CityExample1",
          State = "Colorado",
          Date = DateTime.UtcNow,
          HighTemp = 80,
          LowTemp = 60
        },
        new WeatherData
        {
          City = "CityExample1",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-1),
          HighTemp = 80,
          LowTemp = 60
        },
        new WeatherData
        {
          City = "CityExample1",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-2),
          HighTemp = 60,
          LowTemp = 30
        },
        new WeatherData
        {
          City = "CityExample1",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-4),
          HighTemp = 70,
          LowTemp = 50
        },
        new WeatherData
        {
          City = "CityExample2",
          State = "Alabama",
          Date = DateTime.UtcNow,
          HighTemp = 70,
          LowTemp = 60
        },
        new WeatherData
        {
          City = "CityExample2",
          State = "Alabama",
          Date = DateTime.UtcNow.AddDays(-1),
          HighTemp = 70,
          LowTemp = 50
        },
        new WeatherData
        {
          City = "CityExample2",
          State = "Alabama",
          Date = DateTime.UtcNow.AddDays(-2),
          HighTemp = 70,
          LowTemp = 55
        },
        new WeatherData
        {
          City = "CityExample3",
          State = "New York",
          Date = DateTime.UtcNow,
          HighTemp = 80,
          LowTemp = 60
        },
        new WeatherData {City = "CityExample4", State = "Florida", Date = DateTime.UtcNow, HighTemp = 80, LowTemp = 60},
        new WeatherData
        {
          City = "CityExample5",
          State = "Colorado",
          Date = DateTime.UtcNow,
          HighTemp = 80,
          LowTemp = 60
        },
        new WeatherData
        {
          City = "CityExample5",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-1),
          HighTemp = 70,
          LowTemp = 50
        },
        new WeatherData
        {
          City = "CityExample5",
          State = "Colorado",
          Date = DateTime.UtcNow.AddDays(-2),
          HighTemp = 60,
          LowTemp = 40
        }

      };

      // Act
      var result = WeatherService.AggregateWeatherData(validDataPointList.ToArray());

      // Assert
      result.Should().HaveCount(5);
    }

    ///// <summary>
    ///// Valid Test Data
    ///// </summary>
    //public class ValidIndexOfData : IEnumerable<object[]>
    //{
    //  private readonly List<dynamic[]> _data = new List<object[]>
    //  {
    //    //              City, State, Date, HighTemp, LowTemp
    //    new object[] { "CityExample1", "Colorado", DateTime.UtcNow, 80, 60 },
    //    new object[] { "CityExample1", "Colorado", DateTime.UtcNow.AddDays(-1), 80, 60 },
    //    new object[] { "CityExample1", "Colorado", DateTime.UtcNow.AddDays(-2), 60, 30 },
    //    new object[] { "CityExample1", "Colorado", DateTime.UtcNow.AddDays(-4), 70, 50 },
    //    new object[] { "CityExample2", "Alabama", DateTime.UtcNow, 70, 60 },
    //    new object[] { "CityExample2", "Alabama", DateTime.UtcNow.AddDays(-1), 70, 50 },
    //    new object[] { "CityExample2", "Alabama", DateTime.UtcNow.AddDays(-2), 70, 55 },
    //    new object[] { "CityExample3", "New York", DateTime.UtcNow, 80, 60 },
    //    new object[] { "CityExample4", "Florida", DateTime.UtcNow, 80, 60 },
    //    new object[] { "CityExample5", "Colorado", DateTime.UtcNow, 80, 60 },
    //    new object[] { "CityExample5", "Colorado", DateTime.UtcNow.AddDays(-1), 70, 50 },
    //    new object[] { "CityExample5", "Colorado", DateTime.UtcNow.AddDays(-2), 60, 40 }}
    //  };

    //  public IEnumerator<object[]> GetEnumerator()
    //  { return _data.GetEnumerator(); }

    //  IEnumerator IEnumerable.GetEnumerator()
    //  { return GetEnumerator(); }
    //}
  }
}
