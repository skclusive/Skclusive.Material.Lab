using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Skeleton
{
    public partial class Skeleton : MaterialComponent
    {
        public Skeleton() : base("Skeleton")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "span";

        [Parameter]
        public string Width { set; get; }

        [Parameter]
        public string Height { set; get; }

        /// <summary>
        /// The variant to use.
        /// </summary>
        [Parameter]
        public SkeletonVariant Variant { set; get; } = SkeletonVariant.Text;

        /// <summary>
        /// The animation to use.
        /// </summary>
        [Parameter]
        public SkeletonAnimation Animation { set; get; } = SkeletonAnimation.Pulse;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(Variant)}-{Variant}";

                if (Animation != SkeletonAnimation.None)
                    yield return $"{nameof(Animation)}-{Animation}";

                if (ChildContent != null)
                {
                    yield return $"With-Children";

                    if (string.IsNullOrWhiteSpace(Width))
                        yield return "Fit-Content";

                    if (string.IsNullOrWhiteSpace(Height))
                        yield return "Height-Auto";
                }
            }
        }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                if (!string.IsNullOrWhiteSpace(Width))
                    yield return Tuple.Create<string, object>("width", Width.WithUnit());

                if (!string.IsNullOrWhiteSpace(Height))
                    yield return Tuple.Create<string, object>("height", Height.WithUnit());
            }
        }
    }
}
