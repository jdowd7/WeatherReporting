using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WeatherReporting.Common.Enum;
using WeatherReporting.Common.Enum.Extensions;
using WeatherReporting.Domain.Business;
using WeatherReporting.Domain.Model;
using WeatherReporting.Orchestration.Interface;

namespace WeatherReporting.Orchestration.Service
{
  //We are compiling a report on the average temperatures among various cities over each month. 
  //We receive individual daily data points from a weather service. 
  //Given a collection of data points over a given month, average the data into the requested format for easier reporting.

  //Please include tests in the testing framework you are most comfortable with.

  //We prefer your completed work in a Git repo.

  public class WeatherService : IWeatherService
  {
    /// <summary>
    /// Data point collection to store the sanitized data points in categories
    /// </summary>
    private static IDictionary<Tuple<string, State>, TemperatureStoreBusiObj> WeatherDataPointCollection { get; set; }

    /// <summary>
    /// Initialize static container
    /// </summary>
    public WeatherService()
    {
      WeatherDataPointCollection = new Dictionary<Tuple<string, State>, TemperatureStoreBusiObj>();
    }


    /// <inheritdoc />
    public IEnumerable<CityAveragedWeatherData> AggregateWeatherData(WeatherData[] inputData)
    {
      // null & empty check
      if (inputData == null) return new List<CityAveragedWeatherData>();
      if (inputData.Any() == false) return new List<CityAveragedWeatherData>();

      // pull into mem and loop thru
      foreach (var weatherDataPoint in inputData.ToList())
      {
        // validate the model
        if(!ValidateDataWeather(weatherDataPoint)) continue;

        // ensure high temp is greater than low temp
        if (!CheckHighTempGreaterLowTemp(weatherDataPoint)) continue;

        // format a tempValue for key Tuple<string, State> all lowercase least amount of chars
        var nameStateTuple = GetCityStateTuple(weatherDataPoint);

        // Process the data point
        ProcessCityStateDataPoint(nameStateTuple, weatherDataPoint);
      }

      return GetCityAveragedWeatherData();
    }

    /// <inheritdoc />
    public IEnumerable<CityAveragedWeatherData> GetCityAveragedWeatherData()
    {
      return WeatherDataPointCollection.ToList()
        .Select(p => new
          CityAveragedWeatherData()
          {
            City = p.Key.Item1,
            State = EnumExtensions.GetEnumDescription(p.Key.Item2),
            AverageHighTemp = p.Value.GetHighTemperatureAverage(),
            AverageLowTemp = p.Value.GetLowTemperatureAverage()
          });
    }

    /// <inheritdoc />
    public void ProcessCityStateDataPoint(Tuple<string, State> nameStateTuple, WeatherData weatherDataPoint)
    {
      // check to see if the key exists
      if (!WeatherDataPointCollection.ContainsKey(nameStateTuple))
      {
        // if it doesn't, add it to the dictionary
        WeatherDataPointCollection.Add(nameStateTuple, new TemperatureStoreBusiObj(weatherDataPoint.HighTemp, weatherDataPoint.LowTemp));
      }
      else
      {
        // if it does, look up the key and add to its list
        WeatherDataPointCollection[nameStateTuple].AddTemperaturePair(weatherDataPoint.HighTemp, weatherDataPoint.LowTemp);
      }
    }

    /// <inheritdoc />
    public Tuple<string, State> GetCityStateTuple(WeatherData weatherDataPoint)
    {
      return new Tuple<string, State>(weatherDataPoint.City.ToUpper(), EnumExtensions.GetValueFromDescription<State>(weatherDataPoint.State));
    }

    public bool CheckHighTempGreaterLowTemp(WeatherData weatherDataPoint)
    {
      return weatherDataPoint.HighTemp > weatherDataPoint.LowTemp;
    }

    /// <inheritdoc />
    public bool ValidateDataWeather(WeatherData weatherDataPoint)
    {
      var validationResults = new List<ValidationResult>();
      var context = new ValidationContext(typeof(WeatherData), null, null);
      return Validator.TryValidateObject(typeof(WeatherData), context, validationResults, true);
    }
  }
}
