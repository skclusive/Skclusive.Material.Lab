using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Alert
{
    public partial class Alert : MaterialComponent
    {
        public Alert() : base("Alert")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// The action to display. It renders after the message, at the end of the alert.
        /// </summary>
        [Parameter]
        public RenderFragment ActionContent { set; get; }

        /// <summary>
        /// Override the default label for the *close popup* icon button.
        /// </summary>
        [Parameter]
        public string CloseText { set; get; } = "Close";

        /// <summary>
        /// Override the icon displayed before the children. Unless provided, the icon is mapped to the value of the <c>Severity</c> prop.
        /// </summary>
        [Parameter]
        public RenderFragment IconContent { set; get; }

        /// <summary>
        /// To skip Icon rendering.
        /// </summary>
        [Parameter]
        public bool NoIcon { set; get; }

        /// <summary>
        /// Callback fired when the component requests to be closed.
        /// When provided and no `action` prop is set, a close icon button is displayed that triggers the callback when clicked.
        /// </summary>
        [Parameter]
        public EventCallback<EventArgs> OnClose { get; set; }

        /// <summary>
        /// The severity of the alert. This defines the color and icon used.
        /// </summary>
        [Parameter]
        public AlertSeverity Severity { set; get; } = AlertSeverity.Success;

        /// <summary>
        /// The variant to use.
        /// </summary>
        [Parameter]
        public AlertVariant Variant { set; get; } = AlertVariant.Standard;

        /// <summary>
        /// <c>style</c> applied on the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string IconStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string IconClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string MessageStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string MessageClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string ActionStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string ActionClass { set; get; }

        protected string _Role => _Role ?? "alert";

        protected bool HasAction => ActionContent != null;

        protected bool HasClose => !HasAction && OnClose.HasDelegate;

        protected bool ShowIcon => !NoIcon;

        protected bool HasIcon => IconContent != null;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{Variant}";

                yield return $"{Variant}-{Severity}";
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
            get => CssUtil.ToClass(Selector, IconClasses, IconClass);
        }

        protected virtual IEnumerable<string> IconClasses
        {
            get
            {
                yield return "Icon";
            }
        }

        protected virtual string _MessageStyle
        {
            get => CssUtil.ToStyle(MessageStyles, MessageStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> MessageStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _MessageClass
        {
            get => CssUtil.ToClass(Selector, MessageClasses, MessageClass);
        }

        protected virtual IEnumerable<string> MessageClasses
        {
            get
            {
                yield return "Message";
            }
        }

        protected virtual string _ActionStyle
        {
            get => CssUtil.ToStyle(ActionStyles, ActionStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ActionStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ActionClass
        {
            get => CssUtil.ToClass(Selector, ActionClasses, ActionClass);
        }

        protected virtual IEnumerable<string> ActionClasses
        {
            get
            {
                yield return "Action";
            }
        }
    }
}
