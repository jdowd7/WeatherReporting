using System;
using SimpleInjector;
using WeatherReporting.Orchestration.Interface;
using WeatherReporting.Orchestration.Service;
using Xunit.Abstractions;

namespace WeatherReportingTest.Infrastucture
{
  public class TestContainer
  {
    public Container Container { get; set; }

    public TestContainer()
    {
      Container = new Container();
      var lifeStyle = Lifestyle.Singleton;

      Container.Register<IWeatherService, WeatherService>(lifeStyle);
    }

    /// <summary>
    /// Dispose resources
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases unmanaged resources used and optionally releases the managed resources as well.
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        Container.Dispose();
      }
    }
  }
}