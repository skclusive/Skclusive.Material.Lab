using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Typography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Material.Alert
{
    public partial class AlertTitle : MaterialComponent
    {
        public AlertTitle() : base("AlertTitle")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";
    }
}
