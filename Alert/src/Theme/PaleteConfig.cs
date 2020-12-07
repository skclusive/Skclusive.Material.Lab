using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Alert
{
    // TODO: would be removed once integrated with Material.Component
    public partial class AlertPaletteConfig
    {
        [JsonPropertyName("contrastThreshold")]
        public decimal? ContrastThreshold { get; set; }

        [JsonPropertyName("tonalOffset")]
        public decimal? TonalOffset { get; set; }

        [JsonPropertyName("success")]
        public PaletteColorConfig Success { get; set; }

        [JsonPropertyName("warning")]
        public PaletteColorConfig Warning { get; set; }

        [JsonPropertyName("info")]
        public PaletteColorConfig Info { get; set; }
    }
}