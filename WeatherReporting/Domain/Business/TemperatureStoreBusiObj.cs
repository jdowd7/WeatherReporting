using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherReporting.Domain.Business
{
  /// <summary>
  /// Could have done WeatherDataPoint validation in here
  /// </summary>
  public class TemperatureStoreBusiObj
  {
    public static List<TemperatureDate> HighTemperatureStore { get; private set; }

    public static List<TemperatureDate> LowTemperatureStore { get; private set; }

    public static decimal HighTemperatureAverage { get; set; }

    public static decimal LowTemperatureAverage { get; set; }

    public TemperatureStoreBusiObj(decimal firstHighTemp, decimal firstLowTemp, DateTime firstDate)
    {
      HighTemperatureStore = new List<TemperatureDate> { new TemperatureDate(firstHighTemp, firstDate.Date) };
      LowTemperatureStore = new List<TemperatureDate> { new TemperatureDate(firstLowTemp, firstDate.Date) };
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

    public void AddTemperaturePair(decimal highTemp, decimal lowTemp, DateTime date)
    {
      AddToHighTemperatureStore(highTemp, date);
      AddToLowTemperatureStore(lowTemp, date);
      RecalculateAverages();
    }

    private void AddToHighTemperatureStore(decimal highTemp, DateTime date)
    {
      HighTemperatureStore.Add(new TemperatureDate(highTemp, date));
    }

    private void AddToLowTemperatureStore(decimal lowTemp, DateTime date)
    {
      LowTemperatureStore.Add(new TemperatureDate(lowTemp, date));
    }

    private void RecalculateAverages()
    {
      HighTemperatureAverage = HighTemperatureStore.Average(h => h.Temperature);
      LowTemperatureAverage = LowTemperatureStore.Average(l => l.Temperature);
    }

    public class TemperatureDate
    {
      public decimal Temperature { get; }
      public DateTime Date { get; }

      public TemperatureDate(decimal temperature, DateTime date)
      {
        Temperature = temperature;
        Date = date;
      }
    }
}
}