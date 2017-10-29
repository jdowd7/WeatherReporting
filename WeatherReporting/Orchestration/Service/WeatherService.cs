using System.Collections.Generic;
using System.Linq;
using WeatherReporting.Model;
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
    private static IDictionary<string, List<WeatherData>> WeatherDataPointCollection { get; set; }

    /// <summary>
    /// Initialize static container
    /// </summary>
    public WeatherService()
    {
      WeatherDataPointCollection = new Dictionary<string, List<WeatherData>>();
    }


    /// <inheritdoc />
    public IEnumerable<CityAveragedWeatherData> AggregateWeatherData(WeatherData[] inputData)
    {
      // null & empty check
      if (inputData == null) return new List<CityAveragedWeatherData>();
      if (inputData.Any() == false) return new List<CityAveragedWeatherData>();

      foreach (var weatherDataPoint in inputData.ToList())
      {
        // validate the model

        // format a tempValue for key ("City|State") all lowercase least amount of chars

        // add it to the dictionary

      }




      return null;
    }
  }
}
