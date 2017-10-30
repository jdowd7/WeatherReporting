using System;
using System.ComponentModel.DataAnnotations;
using WeatherReporting.Common.Enum;
using WeatherReporting.Common.Validation;

namespace WeatherReporting.Domain.Model
{
  public class WeatherData
  {
    [Required]
    [ContainsState]
    public string State { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [StringLength(256, ErrorMessage = "City exceeds max length.")]
    public string City { get; set; }

    [Required]
    [DataType(DataType.Date, ErrorMessage = "Not a valid date.")]
    public DateTime Date { get; set; }

    [Required]
    [Range(typeof(decimal), "-459.67", "400", ErrorMessage = "Need valid temperature.")]
    public decimal HighTemp { get; set; }

    [Required]
    [Range(typeof(decimal), "-459.67", "400", ErrorMessage = "Need valid temperature.")]
    public decimal LowTemp { get; set; }
  }
}