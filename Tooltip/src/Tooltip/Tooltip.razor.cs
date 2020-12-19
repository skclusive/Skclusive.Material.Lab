using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Tooltip
{
    public partial class Tooltip : MaterialComponent
    {
        public Tooltip() : base("Tooltip")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// tooltip transition duration.
        /// </summary>
        [Parameter]
        public int? TransitionDuration { set; get; }

        /// <summary>
        /// tooltip appear timeout.
        /// </summary>
        [Parameter]
        public int? AppearTimeout { set; get; }

        /// <summary>
        /// tooltip enter timeout.
        /// </summary>
        [Parameter]
        public int? EnterTimeout { set; get; }

        /// <summary>
        /// tooltip exit timeout.
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
        public bool MountOnEnter { set; get; } = true;

        /// <summary>
        /// By default the child component stays mounted after it reaches the <c>'exited'</c> state.
        /// Set <c>UnmountOnExit</c> if you'd prefer to unmount the component after it finishes exiting.
        /// </summary>
        [Parameter]
        public bool UnmountOnExit { set; get; } = true;

        [Parameter]
        public bool DisableTouchListener { get; set; } = true;

        [Parameter]
        public bool DisableHoverListener { get; set; } = false;

        [Parameter]
        public bool DisableFocusListener { get; set; } = true;

        /// <summary>
        /// tooltip title.
        /// </summary>
        [Parameter]
        public string Title { set; get; }

        /// <summary>
        /// Override the tooltip title.
        /// </summary>
        [Parameter]
        public RenderFragment TitleContent { set; get; }

        [Parameter]
        public bool Arrow { get; set; } = false;

        [Parameter]
        public Alignment Alignment { get; set; } = Alignment.Bottom;

        /// <summary>
        /// <c>style</c> applied on the <c>popper</c> element.
        /// </summary>
        [Parameter]
        public string PopperStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>popper</c> element.
        /// </summary>
        [Parameter]
        public string PopperClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>arrow</c> element.
        /// </summary>
        [Parameter]
        public string ArrowStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>arrow</c> element.
        /// </summary>
        [Parameter]
        public string ArrowClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>title</c> element.
        /// </summary>
        [Parameter]
        public string TitleStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>title</c> element.
        /// </summary>
        [Parameter]
        public string TitleClass { set; get; }

        private bool Open { get; set; }

        private IReference AnchorRef { set; get; } = new Reference();

        private bool HasTitleContent => TitleContent != null;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;
            }
        }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("display", "inline-block");
            }
        }

        protected virtual string _ArrowStyle
        {
            get => CssUtil.ToStyle(ArrowStyles, ArrowStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ArrowStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ArrowClass
        {
            get => CssUtil.ToClass(Selector, ArrowClasses, ArrowClass);
        }

        protected virtual IEnumerable<string> ArrowClasses
        {
            get
            {
                yield return "Arrow";
            }
        }

        protected virtual string _PopperStyle
        {
            get => CssUtil.ToStyle(PopperStyles, PopperStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> PopperStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _PopperClass
        {
            get => CssUtil.ToClass(Selector, PopperClasses, PopperClass);
        }

        protected virtual IEnumerable<string> PopperClasses
        {
            get
            {
                yield return "Popper";
            }
        }

        protected virtual string _TitleStyle
        {
            get => CssUtil.ToStyle(TitleStyles, TitleStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> TitleStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _TitleClass
        {
            get => CssUtil.ToClass($"{Selector}-Title", TitleClasses, TitleClass);
        }

        protected virtual IEnumerable<string> TitleClasses
        {
            get
            {
                yield return string.Empty;

                yield return $"{nameof(Alignment)}-{Alignment}";

                if (Arrow)
                {
                    yield return $"{nameof(Arrow)}";
                }
            }
        }

        private async Task HandleOpenChangedAsync(bool open)
        {
            Open = open;

            await InvokeAsync(StateHasChanged);
        }

        protected override Task HandleTouchStartAsync(TouchEventArgs args)
        {
            if (DisableTouchListener)
            {
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        protected override Task HandleTouchEndAsync(TouchEventArgs args)
        {
            if (DisableTouchListener)
            {
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        protected override async Task HandleMouseEnterAsync(EventArgs args)
        {
            if (DisableHoverListener)
            {
                return;
            }

            await HandleOpenChangedAsync(true);
        }

        protected override async Task HandleMouseLeaveAsync(EventArgs args)
        {
            if (DisableHoverListener)
            {
                return;
            }

            await HandleOpenChangedAsync(false);
        }

        protected override Task HandleFocusAsync(FocusEventArgs args)
        {
            if (DisableFocusListener)
            {
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        protected override Task HandleBlurAsync(FocusEventArgs args)
        {
            if (DisableFocusListener)
            {
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
