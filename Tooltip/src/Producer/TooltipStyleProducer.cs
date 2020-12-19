using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Tooltip
{
    public class TooltipStyleProducer : IStyleProducer
    {
        public IDictionary<string, string> Variables(ThemeValue theme)
        {
            return new Dictionary<string, string>
            {
                ["--theme-zindex-tooltip"] = 1500.ToString(CultureInfo.InvariantCulture),
                ["--theme-component-tooltip-title-background"] = (theme.Palette.Grey.X700.Fade(0.92m)).ToString(CultureInfo.InvariantCulture),
                ["--theme-component-tooltip-title-font-size"] = (theme.Typography.PxToRem(11)).ToString(CultureInfo.InvariantCulture),
                ["--theme-component-tooltip-arrow-color"] = (theme.Palette.Grey.X700.Fade(0.9m)).ToString(CultureInfo.InvariantCulture),
                ["--theme-component-tooltip-touch-font-size"] = (theme.Typography.PxToRem(14)).ToString(CultureInfo.InvariantCulture),
            };
        }
    }
}