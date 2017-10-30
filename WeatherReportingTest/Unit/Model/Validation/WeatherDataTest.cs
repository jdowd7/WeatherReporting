using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
using WeatherReporting.Domain.Model;

namespace WeatherReportingTest.Unit.Model.Validation
{
  public class WeatherDataTest
  {
    #region State Validations

    /// <summary>
    /// Test valid State for WeatherData Model
    /// </summary>
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

      var context = new ValidationContext(dataPointValidState, null, null)
      {
        MemberName = "State"
      };
      var results = new List<ValidationResult>();

      // Act
      var validationResult = Validator.TryValidateProperty(dataPointValidState.State, context, results);

      // Assert
      validationResult.Should().BeTrue();
    }

    /// <summary>
    /// Test Invalid State for WeatherData Model
    /// </summary>
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

      var context = new ValidationContext(dataPointValidState, null, null)
      {
        MemberName = "State"
      };
      var results = new List<ValidationResult>();

      // Act
      var validationResult = Validator.TryValidateProperty(dataPointValidState.State, context, results);

      // Assert
      validationResult.Should().BeFalse();
    }

    #endregion

    #region City Validations

    /// <summary>
    /// Test valid City for WeatherData Model
    /// </summary>
    [Fact]
    public void CityValidation_ValidCityGiven_ShouldReturnTrue()
    {
      // Arrange
      var dataPointValidState = new WeatherData
      {
        City = "Boulder",
        State = "Colorado",
        HighTemp = 80,
        LowTemp = 45
      };

      var context = new ValidationContext(dataPointValidState, null, null)
      {
        MemberName = "City"
      };
      var results = new List<ValidationResult>();

      // Act
      var validationResult = Validator.TryValidateProperty(dataPointValidState.City, context, results);

      // Assert
      validationResult.Should().BeTrue();
    }

    /// <summary>
    /// Test Invalid City for WeatherData Model
    /// </summary>
    [Fact]
    public void CityValidation_256CharCityGiven_ShouldReturnFalse()
    {
      // Arrange
      var dataPointValidState = new WeatherData
      {
        City = "BouldercoloradoBouldercoloradoBouldercoloradoBouldercoloradoBouldercoloradoBouldercolorado" +
               "BouldercoloradoBouldercoloradoBouldercoloradoBouldercoloradoBouldercoloradoBouldercolorado" +
               "BouldercoloradoBouldercoloradoBouldercoloradoBouldercoloradoBouldercoloradoBouldercolorado" +
               "BouldercoloradoBouldercoloradoBouldercoloradoBouldercoloradoBouldercoloradoBouldercolorado",
        State = "Colorado",
        HighTemp = 80,
        LowTemp = 45
      };

      var context = new ValidationContext(dataPointValidState, null, null)
      {
        MemberName = "City"
      };
      var results = new List<ValidationResult>();

      // Act
      var validationResult = Validator.TryValidateProperty(dataPointValidState.City, context, results);

      // Assert
      validationResult.Should().BeFalse();
    }

    #endregion

    #region High Temperature Validations

    /// <summary>
    /// Test Valid HighTemp for WeatherData Model (Range -459.67", "400")
    /// </summary>
    [Theory]
    [InlineData(80)]
    [InlineData(-459.67)]
    [InlineData(400)]
    public void HighTempValidation_ValidTempGiven_ShouldReturnTrue(decimal highTemp)
    {
      // Arrange
      var dataPointValidState = new WeatherData
      {
        City = "Boulder",
        State = "NotColorado",
        HighTemp = highTemp,
        LowTemp = 45
      };

      var context = new ValidationContext(dataPointValidState, null, null)
      {
        MemberName = "HighTemp"
      };
      var results = new List<ValidationResult>();

      // Act
      var validationResult = Validator.TryValidateProperty(dataPointValidState.HighTemp, context, results);

      // Assert
      validationResult.Should().BeTrue();
    }

    /// <summary>
    /// Test Invalid HighTemp for WeatherData Model (Range -459.67", "400")
    /// </summary>
    [Theory]
    [InlineData(-460)]
    [InlineData(401)]
    public void HighTempValidation_InvalidTempGiven_ShouldReturnFalse(decimal highTemp)
    {
      // Arrange
      var dataPointValidState = new WeatherData
      {
        City = "Boulder",
        State = "NotColorado",
        HighTemp = highTemp,
        LowTemp = 45
      };

      var context = new ValidationContext(dataPointValidState, null, null)
      {
        MemberName = "HighTemp"
      };
      var results = new List<ValidationResult>();

      // Act
      var validationResult = Validator.TryValidateProperty(dataPointValidState.HighTemp, context, results);

      // Assert
      validationResult.Should().BeFalse();
    }

    #endregion

    #region Low Temperature Validations

    /// <summary>
    /// Test Valid LowTemp for WeatherData Model (Range -459.67", "400")
    /// </summary>
    [Theory]
    [InlineData(80)]
    [InlineData(-459.67)]
    [InlineData(400)]
    public void LowTempValidation_ValidTempGiven_ShouldReturnTrue(decimal lowTemp)
    {
      // Arrange
      var dataPointValidState = new WeatherData
      {
        City = "Boulder",
        State = "NotColorado",
        HighTemp = 80,
        LowTemp = lowTemp
      };

      var context = new ValidationContext(dataPointValidState, null, null)
      {
        MemberName = "LowTemp"
      };
      var results = new List<ValidationResult>();

      // Act
      var validationResult = Validator.TryValidateProperty(dataPointValidState.LowTemp, context, results);

      // Assert
      validationResult.Should().BeTrue();
    }

    /// <summary>
    /// Test Invalid LowTemp for WeatherData Model (Range -459.67", "400")
    /// </summary>
    [Theory]
    [InlineData(-460)]
    [InlineData(401)]
    public void LowTempValidation_InvalidTempGiven_ShouldReturnFalse(decimal lowTemp)
    {
      // Arrange
      var dataPointValidState = new WeatherData
      {
        City = "Boulder",
        State = "NotColorado",
        HighTemp = 80,
        LowTemp = lowTemp
      };

      var context = new ValidationContext(dataPointValidState, null, null)
      {
        MemberName = "LowTemp"
      };
      var results = new List<ValidationResult>();

      // Act
      var validationResult = Validator.TryValidateProperty(dataPointValidState.LowTemp, context, results);

      // Assert
      validationResult.Should().BeFalse();
    }

    #endregion
  }
}