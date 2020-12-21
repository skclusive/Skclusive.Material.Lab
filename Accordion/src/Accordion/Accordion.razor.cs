using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Accordion
{
    public partial class Accordion : MaterialComponent
    {
        public Accordion() : base("Accordion")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// Shadow depth, corresponds to `dp` in the spec.
        /// It accepts values between 0 and 24 inclusive.
        /// </summary>
        [Parameter]
        public int Elevation { set; get; } = 1;

        /// <summary>
        /// If <c>true</c>, rounded corners are disabled.
        /// </summary>
        [Parameter]
        public bool Square { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, expands the accordion, otherwise collapse it. Setting this prop enables control over the accordion.
        /// </summary>
        [Parameter]
        public bool Expanded { set; get; } = false;

        /// <summary>
        /// Callback fired when the value is changed.
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnChange { set; get; }

        /// <summary>
        /// To render summary use <c>SummaryContent</c>
        /// </summary>
        [Parameter]
        public RenderFragment SummaryContent { set; get; }

                /// <summary>
        /// popover transition duration.
        /// </summary>
        [Parameter]
        public int? TransitionDuration { set; get; }

        /// <summary>
        /// popover appear timeout.
        /// </summary>
        [Parameter]
        public int? AppearTimeout { set; get; }

        /// <summary>
        /// popover enter timeout.
        /// </summary>
        [Parameter]
        public int? EnterTimeout { set; get; }

        /// <summary>
        /// popover exit timeout.
        /// </summary>
        [Parameter]
        public int? ExitTimeout { set; get; }

        /// <summary>
        /// By default the child component is mounted immediately along with
        /// the parent <c>Transition</c> component. If you want to "lazy mount" the component on the
        /// first <c>In="true"</c> you can set <c>MountOnEnter</c>. After the first enter transition the component will stay
        /// mounted, even on "exited", unless you also specify <c>UnmountOnExit</c>.
        /// </summary>
        [Parameter]
        public bool MountOnEnter { set; get; }

        /// <summary>
        /// By default the child component stays mounted after it reaches the <c>'exited'</c> state.
        /// Set <c>UnmountOnExit</c> if you'd prefer to unmount the component after it finishes exiting.
        /// </summary>
        [Parameter]
        public bool UnmountOnExit { set; get; }

        [Parameter]
        public string SummaryId { set; get; }

        [Parameter]
        public string ControlsId { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Region</c> element.
        /// </summary>
        [Parameter]
        public string RegionStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Region</c> element.
        /// </summary>
        [Parameter]
        public string RegionClass { set; get; }

        protected bool Rounded => !Square;

        protected IAccordionContext AccordionContext => new AccordionContextBuilder()
        .WithExpanded(Expanded)
        .WithDisabled(Disabled)
        .WithOnToggle(OnToggleAsync)
        .Build();

        private async Task OnToggleAsync(EventArgs args)
        {
            if (OnChange.HasDelegate)
            {
                await OnChange.InvokeAsync(!Expanded);
            }
            else
            {
                Expanded = !Expanded;

                await InvokeAsync(StateHasChanged);
            }
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Expanded)
                    yield return $"{nameof(Expanded)}";

                if (Rounded)
                    yield return $"{nameof(Rounded)}";
            }
        }

        protected virtual string _RegionStyle
        {
            get => CssUtil.ToStyle(RegionStyles, RegionStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> RegionStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _RegionClass
        {
            get => CssUtil.ToClass($"{Selector}-Region", RegionClasses, RegionClass);
        }

        protected virtual IEnumerable<string> RegionClasses
        {
            get
            {
                yield return string.Empty;
            }
        }
    }
}
