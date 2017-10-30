using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WeatherReporting.Common.Enum;

namespace WeatherReporting.Common.Validation
{
  /// <inheritdoc />
  public class ContainsStateAttribute : ValidationAttribute
  {
    private static IEnumerable<string> StateDescriptiorsList { get; set; }

    /// <summary>
    /// Probably overkill, but custom attribute validator for the state descriptions enum
    /// </summary>
    public ContainsStateAttribute()
    {
      StateDescriptiorsList = System.Enum.GetValues(typeof(State)).Cast<State>().Select(state => Enum.Extensions.EnumExtensions.GetEnumDescription(state)).ToList();
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      return StateDescriptiorsList.Contains(value) ? ValidationResult.Success : new ValidationResult("Not a valid state");
    }
  }
}