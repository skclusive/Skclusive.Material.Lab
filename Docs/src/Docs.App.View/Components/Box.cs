using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Material.Core;
using Skclusive.Core.Component;
using System;
using System.Globalization;
using System.Collections.Generic;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Docs.App.View
{
    public class Box : MaterialComponent
    {
        public Box() : base("Box")
        {
        }

        [Parameter]
        public double? Margin { set; get; }

        [Parameter]
        public double? MarginRight { set; get; }

        [Parameter]
        public double? MarginLeft { set; get; }

        [Parameter]
        public double? MarginTop { set; get; }

        [Parameter]
        public double? MarginBottom { set; get; }

        [Parameter]
        public double? MR { set; get; }

        [Parameter]
        public double? ML { set; get; }

        [Parameter]
        public double? MB { set; get; }

        [Parameter]
        public double? MT { set; get; }

        [Parameter]
        public double? MY { set; get; }

        [Parameter]
        public double? MX { set; get; }

        [Parameter]
        public double? Padding { set; get; }

        [Parameter]
        public double? PaddingRight { set; get; }

        [Parameter]
        public double? PaddingLeft { set; get; }

        [Parameter]
        public double? PaddingTop { set; get; }

        [Parameter]
        public double? PaddingBottom { set; get; }

        [Parameter]
        public double? PR { set; get; }

        [Parameter]
        public double? PL { set; get; }

        [Parameter]
        public double? PB { set; get; }

        [Parameter]
        public double? PT { set; get; }

        [Parameter]
        public double? PY { set; get; }

        [Parameter]
        public double? PX { set; get; }

        [Parameter]
        public string Display { set; get; }

        [Parameter]
        public Overflow Overflow { set; get; } = Overflow.Visible;

        [Parameter]
        public string AlignItems { set; get; }

        [Parameter]
        public string Width { set; get; }

        [Parameter]
        public string Height { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "style", _Style);
            builder.AddAttribute(2, "class", _Class);
            builder.AddMultipleAttributes(3, Attributes);
            builder.AddContent(4, ChildContent);
            builder.AddElementReferenceCapture(5, (__value) => {
                RootRef.Current = (ElementReference)__value;
            });
            builder.CloseElement();
        }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                if (Margin.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin", $"calc(var(--theme-spacing) * {Margin.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (MarginRight.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-right", $"calc(var(--theme-spacing) * {MarginRight.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (MarginLeft.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-left", $"calc(var(--theme-spacing) * {MarginLeft.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (MarginTop.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-top", $"calc(var(--theme-spacing) * {MarginTop.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (MarginBottom.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-bottom", $"calc(var(--theme-spacing) * {MarginBottom.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (MR.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-right", $"calc(var(--theme-spacing) * {MR.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (ML.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-left", $"calc(var(--theme-spacing) * {ML.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (MT.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-top", $"calc(var(--theme-spacing) * {MT.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (MB.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-bottom", $"calc(var(--theme-spacing) * {MB.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (MY.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-top", $"calc(var(--theme-spacing) * {MY.Value.ToString(CultureInfo.InvariantCulture)}px)");
                    yield return Tuple.Create<string, object>("margin-bottom", $"calc(var(--theme-spacing) * {MY.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (MX.HasValue)
                {
                    yield return Tuple.Create<string, object>("margin-left", $"calc(var(--theme-spacing) * {MX.Value.ToString(CultureInfo.InvariantCulture)}px)");
                    yield return Tuple.Create<string, object>("margin-right", $"calc(var(--theme-spacing) * {MX.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (Padding.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding", $"calc(var(--theme-spacing) * {Padding.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PaddingRight.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-right", $"calc(var(--theme-spacing) * {PaddingRight.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PaddingLeft.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-left", $"calc(var(--theme-spacing) * {PaddingLeft.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PaddingTop.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-top", $"calc(var(--theme-spacing) * {PaddingTop.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PaddingBottom.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-bottom", $"calc(var(--theme-spacing) * {PaddingBottom.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PR.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-right", $"calc(var(--theme-spacing) * {PR.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PL.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-left", $"calc(var(--theme-spacing) * {PL.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PT.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-top", $"calc(var(--theme-spacing) * {PT.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PB.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-bottom", $"calc(var(--theme-spacing) * {PB.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PY.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-top", $"calc(var(--theme-spacing) * {PY.Value.ToString(CultureInfo.InvariantCulture)}px)");
                    yield return Tuple.Create<string, object>("padding-bottom", $"calc(var(--theme-spacing) * {PY.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (PX.HasValue)
                {
                    yield return Tuple.Create<string, object>("padding-left", $"calc(var(--theme-spacing) * {PX.Value.ToString(CultureInfo.InvariantCulture)}px)");
                    yield return Tuple.Create<string, object>("padding-right", $"calc(var(--theme-spacing) * {PX.Value.ToString(CultureInfo.InvariantCulture)}px)");
                }

                if (!string.IsNullOrWhiteSpace(Display))
                {
                    yield return Tuple.Create<string, object>("display", Display.ToLower(CultureInfo.InvariantCulture));
                }

                if (!string.IsNullOrWhiteSpace(AlignItems))
                {
                    yield return Tuple.Create<string, object>("align-items", AlignItems.ToLower(CultureInfo.InvariantCulture));
                }

                if (Overflow != Overflow.Visible)
                {
                    yield return Tuple.Create<string, object>("overflow", Overflow.ToString().ToLower(CultureInfo.InvariantCulture));
                }

                if (!string.IsNullOrWhiteSpace(Width))
                {
                    yield return Tuple.Create<string, object>("width", Width.WithUnit());
                }

                if (!string.IsNullOrWhiteSpace(Height))
                {
                    yield return Tuple.Create<string, object>("height", Height.WithUnit());
                }
            }
        }
    }
}
