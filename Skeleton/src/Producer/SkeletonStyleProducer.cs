using System;
using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Skeleton
{
    public class SkeletonStyleProducer : IStyleProducer
    {
        public IDictionary<string, string> Variables(ThemeValue theme)
        {
             var isDark = theme.IsDark();

            var radiusUnit = theme.Shape.BorderRadius.ToString().ToUnit("px");

            var radiusValue = theme.Shape.BorderRadius.ToString().ToUnitless();

            return new Dictionary<string, string>
            {
                ["--theme-component-skeleton-background"] = (theme.Palette.Text.Primary.Fade(isDark ? 0.13m : 0.11m)).ToString(CultureInfo.InvariantCulture),
                ["--theme-component-skeleton-text-border-radius"] = ($"{radiusValue.ToString(CultureInfo.InvariantCulture)}{radiusUnit}/{(Math.Round((radiusValue / 0.6) * 10) / 10).ToString(CultureInfo.InvariantCulture)}{radiusUnit}"),
            };
        }
    }
}