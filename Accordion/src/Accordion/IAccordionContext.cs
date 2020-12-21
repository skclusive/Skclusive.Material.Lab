using System;
using System.Threading.Tasks;
using Skclusive.Core.Component;

namespace Skclusive.Material.Accordion
{
    public interface IAccordionContext : IComponentContext
    {
        bool Expanded { get; }

        Func<EventArgs, Task> OnToggle { get; }
    }

    public class AccordionContextBuilder : ComponentContextBuilder<AccordionContextBuilder, IAccordionContext>
    {
        protected class AccordionContext : ComponentContext, IAccordionContext
        {
            public bool Expanded { get; internal set; }
            public Func<EventArgs, Task> OnToggle { get; internal set; }
        }

        public AccordionContextBuilder() : base(new AccordionContext())
        {
        }

        protected override AccordionContextBuilder This() => this;

        protected AccordionContext AContext => Context as AccordionContext;

        public AccordionContextBuilder WithExpanded(bool expanded)
        {
            AContext.Expanded = expanded;

            return this;
        }

        public AccordionContextBuilder WithOnToggle(Func<EventArgs, Task> toggle)
        {
            AContext.OnToggle = toggle;

            return this;
        }

        public override AccordionContextBuilder With(IAccordionContext context)
        {
            base.With(context);

            WithExpanded(context.Expanded);
            WithOnToggle(context.OnToggle);

            return this;
        }
    }
}