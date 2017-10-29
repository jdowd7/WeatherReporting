using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeatherReporting.Model;
using Xunit;
using FluentAssertions;

namespace WeatherReportingTest.Unit.Model.Validation
{
    public class WeatherDataTest
    {
      [Fact]
      public void StateValidation_FullStateGiven_ShouldReturnTrue()
      {
        // Arrange
        var dataPointValidState = new WeatherData
        {
          City = "Boulder",
          State = "Colorado",
          HighTemp = 80,
          LowTemp = 45
        };

        ValidationContext context = new ValidationContext(dataPointValidState, null, null);
        List<ValidationResult> results = new List<ValidationResult>();

        // Act
        bool validationResult = Validator.TryValidateProperty(dataPointValidState.State, context, results);

        // Assert
        validationResult.Should().BeTrue();
      }

      [Theory]
      [InlineData(1)]
      public void TestMethod2(int one)
      {
      }
    }
  }