using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Alert
{
    // TODO: would be removed once integrated with Material.Component
    public partial class AlertPalette
    {
        [JsonPropertyName("success")]
        public PaletteColor Success { get; set; }

        [JsonPropertyName("warning")]
        public PaletteColor Warning { get; set; }

        [JsonPropertyName("info")]
        public PaletteColor Info { get; set; }
    }
}