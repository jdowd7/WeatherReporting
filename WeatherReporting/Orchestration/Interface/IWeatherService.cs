using System.Collections.Generic;
using WeatherReporting.Model;

namespace WeatherReporting.Orchestration.Interface
{
  interface IWeatherService
  {

    /// <summary>
    /// Primary Method that sanitizies, categorizes, and calculates average temparatures for referenced US Cities.
    /// </summary>
    /// <param name="inputData"></param>
    /// <returns></returns>
    IEnumerable<CityAveragedWeatherData> AggregateWeatherData(WeatherData[] inputData);
  }
}
