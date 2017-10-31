using System;
using System.Collections.Generic;
using WeatherReporting.Common.Enum;
using WeatherReporting.Domain.Model;

namespace WeatherReporting.Orchestration.Interface
{
  public interface IWeatherService
  {

    /// <summary>
    /// Primary Method that sanitizies, categorizes, and calculates average temparatures for referenced US Cities.
    /// </summary>
    /// <param name="inputData"></param>
    /// <returns><see cref="List{T}"/></returns>
    IEnumerable<CityAveragedWeatherData> AggregateWeatherData(WeatherData[] inputData);

    /// <summary>
    /// Validation Method that verifies the parameters provided for the WeatherData model are correct.
    /// </summary>
    /// <param name="weatherDataPoint"></param>
    /// <returns><see cref="bool"/></returns>
    /// <remarks>Normally this would be called on creation of a Weather Data model but not part of problem asked.</remarks>
    bool ValidateDataWeather(WeatherData weatherDataPoint);

    /// <summary>
    /// Check to make sure High temp is greater than the low temp.
    /// </summary>
    /// <param name="weatherDataPoint"></param>
    /// <returns><see cref="bool"/></returns>
    /// <remarks>Could have put in model valuation.</remarks>
    bool CheckHighTempGreaterLowTemp(WeatherData weatherDataPoint);

    /// <summary>
    /// Returns a Tuple based on the City and State of the data point.
    /// </summary>
    /// <param name="weatherDataPoint"></param>
    /// <returns><see cref="Tuple{T1}"/></returns>
    Tuple<string, State> GetCityStateTuple(WeatherData weatherDataPoint);

    /// <summary>
    /// Categorizes the data point based on the City and State and stores/processes the temperature information.
    /// </summary>
    /// <param name="nameStateTuple"></param>
    /// <param name="weatherDataPoint"></param>
    void ProcessCityStateDataPoint(Tuple<string, State> nameStateTuple, WeatherData weatherDataPoint);

    /// <summary>
    /// Converts data point collection object to a collection of CityAveragedWeatherData models.
    /// </summary>
    /// <returns><see cref="List{T}"/></returns>
    IEnumerable<CityAveragedWeatherData> GetCityAveragedWeatherData();
  }
}
