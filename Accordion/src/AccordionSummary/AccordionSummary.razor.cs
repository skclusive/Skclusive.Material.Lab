using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Accordion
{
    public partial class AccordionSummary : MaterialComponent
    {
        public AccordionSummary() : base("AccordionSummary")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// Reference attached to the child element of the component.
        /// </summary>
        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        /// <summary>
        /// This prop can help a person know which element has the keyboard focus.
        /// The class name will be applied when the element gain the focus through a keyboard interaction.
        /// It's a polyfill for the [CSS :focus-visible selector](https://drafts.csswg.org/selectors-4/#the-focus-visible-pseudo).
        /// The rationale for using this feature [is explained here](https://github.com/WICG/focus-visible/blob/master/explainer.md).
        /// A [polyfill can be used](https://github.com/WICG/focus-visible) to apply a `focus-visible` class to other components
        /// if needed.
        /// </summary>
        [Parameter]
        public string FocusVisibleClass { set; get; }

        /// <summary>
        /// To render expand icon use <c>IconContent</c>
        /// </summary>
        [Parameter]
        public RenderFragment IconContent { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Content</c> element.
        /// </summary>
        [Parameter]
        public string ContentStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Content</c> element.
        /// </summary>
        [Parameter]
        public string ContentClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Icon</c> element.
        /// </summary>
        [Parameter]
        public string IconStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Icon</c> element.
        /// </summary>
        [Parameter]
        public string IconClass { set; get; }

        [CascadingParameter]
        public IAccordionContext AccordionContext { set; get; }

        protected bool? _Disabled => AccordionContext.Disabled;

        protected bool Expanded => AccordionContext.Expanded;

        protected Func<EventArgs, Task> OnToggle => AccordionContext.OnToggle;

        protected bool HasIconContent => IconContent != null;

        protected override async Task HandleClickAsync(EventArgs args)
        {
            await OnToggle.Invoke(args);

            await base.HandleClickAsync(args);
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Expanded)
                    yield return $"{nameof(Expanded)}";
            }
        }


        protected virtual string _ContentStyle
        {
            get => CssUtil.ToStyle(ContentStyles, ContentStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ContentStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ContentClass
        {
            get => CssUtil.ToClass($"{Selector}-Content", ContentClasses, ContentClass);
        }

        protected virtual IEnumerable<string> ContentClasses
        {
            get
            {
                yield return string.Empty;

                if (Expanded)
                    yield return $"{nameof(Expanded)}";
            }
        }


        protected virtual string _IconStyle
        {
            get => CssUtil.ToStyle(IconStyles, IconStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> IconStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _IconClass
        {
            get => CssUtil.ToClass($"{Selector}-Icon", IconClasses, IconClass);
        }

        protected virtual IEnumerable<string> IconClasses
        {
            get
            {
                yield return string.Empty;

                if (Expanded)
                    yield return $"{nameof(Expanded)}";
            }
        }
    }
}
