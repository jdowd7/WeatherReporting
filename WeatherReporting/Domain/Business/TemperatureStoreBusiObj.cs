using System.Collections.Generic;
using System.Linq;

namespace WeatherReporting.Domain.Business
{
  /// <summary>
  /// Could have done WeatherDataPoint validation in here
  /// </summary>
  public class TemperatureStoreBusiObj
  {
    public static List<decimal> HighTemperatureStore { get; private set; }

    public static List<decimal> LowTemperatureStore { get; private set; }

    public static decimal HighTemperatureAverage { get; set; }

    public static decimal LowTemperatureAverage { get; set; }

    public TemperatureStoreBusiObj(decimal firstHighTemp, decimal firstLowTemp)
    {
      HighTemperatureStore = new List<decimal> { firstHighTemp };
      LowTemperatureStore = new List<decimal> { firstLowTemp };
      HighTemperatureAverage = firstHighTemp;
      LowTemperatureAverage = firstLowTemp;
    }

    public decimal GetHighTemperatureAverage()
    {
      return HighTemperatureAverage;
    }

    public decimal GetLowTemperatureAverage()
    {
      return LowTemperatureAverage;
    }

    public void AddTemperaturePair(decimal highTemp, decimal lowTemp)
    {
      AddToHighTemperatureStore(highTemp);
      AddToLowTemperatureStore(lowTemp);
      RecalculateAverages();
    }

    private void AddToHighTemperatureStore(decimal highTemp)
    {
      HighTemperatureStore.Add(highTemp);
    }

    private void AddToLowTemperatureStore(decimal lowTemp)
    {
      LowTemperatureStore.Add(lowTemp);
    }

    private void RecalculateAverages()
    {
      HighTemperatureAverage = HighTemperatureStore.Average();
      LowTemperatureAverage = LowTemperatureStore.Average();
    }

  }
}