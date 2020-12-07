using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Alert
{
    public class AlertStyleProducer : IStyleProducer
    {
        // TODO: would be removed once integrated with Material.Component
        private AlertPalette Light { get; }

        // TODO: would be removed once integrated with Material.Component
        private AlertPalette Dark { get; }

        // TODO: would be removed once integrated with Material.Component
        public AlertStyleProducer(AlertPaletteConfig light, AlertPaletteConfig dark)
        {
            Light = ToPaletteColor(light ?? new AlertPaletteConfig());

            Dark = ToPaletteColor(dark ?? new AlertPaletteConfig());
        }

        public static AlertPalette ToPaletteColor(AlertPaletteConfig config)
        {
            var tonalOffset = config.TonalOffset ?? 0.2m;

            var contrastThreshold = config.ContrastThreshold ?? 3;

            return new AlertPalette
            {
                Success = PaletteFactory.AugmentColor(config.Success ?? new PaletteColorConfig
                {
                    Light = PaletteColors.Green.X300,

                    Main = PaletteColors.Green.X500,

                    Dark = PaletteColors.Green.X700

                }, tonalOffset, contrastThreshold),

                Warning = PaletteFactory.AugmentColor(config.Warning ?? new PaletteColorConfig
                {
                    Light = PaletteColors.Orange.X300,

                    Main = PaletteColors.Orange.X500,

                    Dark = PaletteColors.Orange.X700

                }, tonalOffset, contrastThreshold),

                Info = PaletteFactory.AugmentColor(config.Info ?? new PaletteColorConfig
                {
                    Light = PaletteColors.Blue.X300,

                    Main = PaletteColors.Blue.X500,

                    Dark = PaletteColors.Blue.X700

                }, tonalOffset, contrastThreshold),
            };
        }

        public IDictionary<string, string> Variables(ThemeValue theme)
        {
            var isDark = theme.IsDark();

            var palette = isDark ? Dark : Light;

            return new Dictionary<string, string>
            {
                ["--theme-palette-error-color"] = (isDark ? theme.Palette.Error.Main.Lighten(0.6m) : theme.Palette.Error.Main.Darken(0.6m)).ToString(CultureInfo.InvariantCulture),
                ["--theme-palette-error-background"] = (isDark ? theme.Palette.Error.Main.Darken(0.9m) : theme.Palette.Error.Main.Lighten(0.9m)).ToString(CultureInfo.InvariantCulture),

                ["--theme-palette-success-main"] = (palette.Success.Main.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-success-light"] = (palette.Success.Light.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-success-dark"] = (palette.Success.Dark.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-success-contrast-text"] = (palette.Success.ContrastText.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-success-alternate"] = (isDark ? palette.Success.Light : palette.Success.Dark).ToString(CultureInfo.InvariantCulture),
                ["--theme-palette-success-color"] = (isDark ? palette.Success.Main.Lighten(0.6m) : palette.Success.Main.Darken(0.6m)).ToString(CultureInfo.InvariantCulture),
                ["--theme-palette-success-background"] = (isDark ? palette.Success.Main.Darken(0.9m) : palette.Success.Main.Lighten(0.9m)).ToString(CultureInfo.InvariantCulture),

                ["--theme-palette-warning-main"] = (palette.Warning.Main.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-warning-light"] = (palette.Warning.Light.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-warning-dark"] = (palette.Warning.Dark.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-warning-contrast-text"] = (palette.Warning.ContrastText.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-warning-alternate"] = (isDark ? palette.Warning.Light : palette.Warning.Dark).ToString(CultureInfo.InvariantCulture),
                ["--theme-palette-warning-color"] = (isDark ? palette.Warning.Main.Lighten(0.6m) : palette.Warning.Main.Darken(0.6m)).ToString(CultureInfo.InvariantCulture),
                ["--theme-palette-warning-background"] = (isDark ? palette.Warning.Main.Darken(0.9m) : palette.Warning.Main.Lighten(0.9m)).ToString(CultureInfo.InvariantCulture),

                ["--theme-palette-info-main"] = (palette.Info.Main.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-info-light"] = (palette.Info.Light.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-info-dark"] = (palette.Info.Dark.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-info-contrast-text"] = (palette.Info.ContrastText.ToString(CultureInfo.InvariantCulture)),
                ["--theme-palette-info-alternate"] = (isDark ? palette.Info.Light : palette.Info.Dark).ToString(CultureInfo.InvariantCulture),
                ["--theme-palette-info-color"] = (isDark ? palette.Info.Main.Lighten(0.6m) : palette.Info.Main.Darken(0.6m)).ToString(CultureInfo.InvariantCulture),
                ["--theme-palette-info-background"] = (isDark ? palette.Info.Main.Darken(0.9m) : palette.Info.Main.Lighten(0.9m)).ToString(CultureInfo.InvariantCulture),
            };
        }
    }
}