using System;
using System.ComponentModel;

namespace WeatherReporting.Common.Enum.Extensions
{
  public static class EnumExtensions
  {
    public static string GetEnumDescription(System.Enum value)
    {
      var fi = value.GetType().GetField(value.ToString());

      var attributes =
        (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

      return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }

    public static T GetValueFromDescription<T>(string description)
    {
      var type = typeof(T);
      if (!type.IsEnum) throw new InvalidOperationException();
      foreach (var field in type.GetFields())
      {
        if (Attribute.GetCustomAttribute(field,
          typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
          if (attribute.Description == description)
            return (T)field.GetValue(null);
        }
        else
        {
          if (field.Name == description)
            return (T)field.GetValue(null);
        }
      }
      //throw new ArgumentException("Not found.", "description");
      return default(T);
    }
  }
}