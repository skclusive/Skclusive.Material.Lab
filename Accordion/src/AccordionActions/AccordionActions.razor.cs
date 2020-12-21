﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Accordion
{
    public partial class AccordionActions : MaterialComponent
    {
        public AccordionActions() : base("AccordionActions")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If <c>true</c>, the actions do not have additional margin.
        /// </summary>
        [Parameter]
        public bool DisableSpacing { set; get; }

        protected bool Spacing => !DisableSpacing;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Spacing)
                    yield return $"{nameof(Spacing)}";
            }
        }
    }
}
