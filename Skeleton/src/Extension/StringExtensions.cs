
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace Skclusive.Material.Theme
{
    // TODO: would be removed once integrated with Core.Component
    public static class StringExtraExtensions
    {
        public static double ToUnitless(this string value)
        {
            Match match = Regex.Match(value, @"([\d.\-+]*)\s*(.*)");

            return match.Success && double.TryParse(match.Groups[1].Value, out double unit) ? unit : 0;
        }

        public static string ToUnit(this string value, string defaultUnit = "px")
        {
            Match match = Regex.Match(value, @"[\d.\-+]*\s*(.*)");

            var matched = match.Success ? match.Groups[1].Value : null;

            return string.IsNullOrWhiteSpace(matched) ? defaultUnit : matched;
        }

        public static string WithUnit(this string value, string defaultUnit = "px")
        {
            double unitless = value.ToUnitless();

            string unit = value.ToUnit(defaultUnit);

            return $"{unitless.ToString(CultureInfo.InvariantCulture)}{unit}";
        }
    }
}