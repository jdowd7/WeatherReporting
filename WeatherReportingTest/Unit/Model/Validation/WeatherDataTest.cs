using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using WeatherReporting.Domain.Model;

namespace WeatherReportingTest.Unit.Model.Validation
{
    public class WeatherDataTest
    {
      [Fact]
      public void StateValidation_ValidStateGiven_ShouldReturnTrue()
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
        context.MemberName = "State";
        List<ValidationResult> results = new List<ValidationResult>();

        // Act
        bool validationResult = Validator.TryValidateProperty(dataPointValidState.State, context, results);

        // Assert
        validationResult.Should().BeTrue();
      }

    [Fact]
    public void StateValidation_InvalidStateGiven_ShouldReturnFalse()
    {
      // Arrange
      var dataPointValidState = new WeatherData
      {
        City = "Boulder",
        State = "NotColorado",
        HighTemp = 80,
        LowTemp = 45
      };

      ValidationContext context = new ValidationContext(dataPointValidState, null, null);
      context.MemberName = "State";
      List<ValidationResult> results = new List<ValidationResult>();

      // Act
      bool validationResult = Validator.TryValidateProperty(dataPointValidState.State, context, results);

      // Assert
      validationResult.Should().BeFalse();
    }

    [Theory]
      [InlineData(1)]
      public void TestMethod2(int one)
      {
      }
    }
  }