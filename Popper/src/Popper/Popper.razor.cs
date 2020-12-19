using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Popper
{
    public partial class Popper : MaterialComponentBase
    {
        private static readonly IDictionary<Alignment, string> AlignmentMappings = new Dictionary<Alignment, string>
        {
            [Alignment.Auto] = "auto",
            [Alignment.AutoStart] = "auto-start",
            [Alignment.AutoEnd] = "auto-end",
            [Alignment.Top] = "top",
            [Alignment.TopStart] = "top-start",
            [Alignment.TopEnd] = "top-end",
            [Alignment.Bottom] = "bottom",
            [Alignment.BottomStart] = "bottom-start",
            [Alignment.BottomEnd] = "bottom-end",
            [Alignment.Right] = "right",
            [Alignment.RightStart] = "right-start",
            [Alignment.RightEnd] = "right-end",
            [Alignment.Left] = "left",
            [Alignment.LeftStart] = "left-start",
            [Alignment.LeftEnd] = "left-end",
        };

        private static readonly IDictionary<PopperStrategy, string> StrategyMappings = new Dictionary<PopperStrategy, string>
        {
            [PopperStrategy.Absolute] = "absolute",
            [PopperStrategy.Fixed] = "fixed",
        };

        public Popper() : base("Popper")
        {
        }

        [Inject]
        public PopperHelper PopperHelper { set; get; }

        /// <summary>
        /// Disable the portal behavior.
        /// The children stay within it's parent DOM hierarchy.
        /// </summary>
        [Parameter]
        public bool DisablePortal { get; set; } = false;

        [Parameter]
        public RenderFragment<IPopperContext> ChildContent { get; set; }

        /// <summary>
        /// Reference attached to the portal target.
        /// </summary>
        [Parameter]
        public IReference PortalTargetRef { get; set; }

        /// <summary>
        /// Reference attached to the portal target body.
        /// </summary>
        [Parameter]
        public IReference PortalTargetBodyRef { get; set; }

        /// <summary>
        /// Reference attached to the anchor element of the popper.
        /// </summary>
        [Parameter]
        public IReference AnchorRef { get; set; } = new Reference();

        /// <summary>
        /// Reference attached to the content element of the popper.
        /// </summary>
        [Parameter]
        public IReference ContentAnchorRef { get; set; } = new Reference();

        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        [Parameter]
        public Alignment Alignment { set; get; } = Alignment.Bottom;

        [Parameter]
        public PopperStrategy Strategy { set; get; } = PopperStrategy.Absolute;

        /// <summary>
        /// The elevation of the popper.
        /// </summary>
        [Parameter]
        public bool KeepMounted { set; get; }

        /// <summary>
        /// If <c>true</c>, rounded corners are disabled.
        /// </summary>
        [Parameter]
        public bool Transition { set; get; }

        /// <summary>
        /// If <c>true</c>, the popper is visible.
        /// </summary>
        [Parameter]
        public bool Open { set; get; }

        [Parameter]
        public EventCallback OnClose { set; get; }

        private bool Exited { set; get; } = false;

        private bool CanRender => !(!KeepMounted && !Open && (!Transition || Exited));

        private PopperContextBuilder PopperContextBuilder => new PopperContextBuilder()
            .WithRefBack(ChildRef)
            .WithOpen(Open)
            .WithOnEnter(HandleEnterAsync)
            .WithOnExited(HandleExitedAsync);

        protected Task HandleEnterAsync((IReference, bool) args)
        {
            Exited = false;

            return Task.CompletedTask;
        }

        protected Task HandleExitedAsync(IReference reference)
        {
            Exited = true;

            return HandleCloseAsync();
        }

        protected IPopperContext GetPopperContext(IComponentContext context)
        {
            return PopperContextBuilder.WithRefBack(new DelegateReference(ChildRef, context.RefBack))
                .Build();
        }

        protected void HandleClose(ModalCloseReason reason)
        {
            OnClose.InvokeAsync(reason);
        }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("position", "fixed");

                yield return Tuple.Create<string, object>("top", "0");

                yield return Tuple.Create<string, object>("left", "0");

                if (!Open && KeepMounted && !Transition)
                {
                    yield return Tuple.Create<string, object>("display", "none");
                }
            }
        }

        private IReference PrevAnchorRef { set; get; }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            PrevAnchorRef = AnchorRef;

            await base.SetParametersAsync(parameters);
        }

        protected override async Task OnAfterRenderAsync()
        {
            if (!Open && !Transition || (PrevAnchorRef?.Current?.Id != AnchorRef?.Current?.Id))
            {
                await HandleCloseAsync();
            }

            if (Open && !PopperHelper.Active && AnchorRef?.Current != null)
            {
                await PopperHelper.InitAsync(AnchorRef?.Current, RootRef.Current.Value, new PopperOptions
                {
                    Alignment = AlignmentMappings[Alignment],

                    Strategy = StrategyMappings[Strategy]
                });
            }

            await PopperHelper.UpdateAsync();
        }

        private async Task HandleCloseAsync()
        {
            if (PopperHelper.Active)
            {
                await PopperHelper.DisposeAsync();
            }
        }

        protected override async ValueTask DisposeAsync()
        {
            await HandleCloseAsync();
        }
    }
}
