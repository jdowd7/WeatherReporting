namespace WeatherReporting.Domain.Model
{
  public class CityAveragedWeatherData
  {
    public string State { get; set; }
    public string City { get; set; }
    public decimal AverageHighTemp { get; set; }
    public decimal AverageLowTemp { get; set; }
  }
}