using System;
using System.Threading.Tasks;
using Skclusive.Core.Component;

namespace Skclusive.Material.Popper
{
    public interface IPopperContext : IComponentContext
    {
        bool Open { get; }

        Func<(IReference, bool), Task> OnEnter { get; }

        Func<IReference, Task> OnExited { get; }
    }

    public class PopperContextBuilder : ComponentContextBuilder<PopperContextBuilder, IPopperContext>
    {
        public class PopperContext : ComponentContext, IPopperContext
        {
            public bool Open { get; internal set; }

            public Func<(IReference, bool), Task> OnEnter { get; internal set; }

            public Func<IReference, Task> OnExited { get; internal set; }
        }

        protected PopperContext PContext => base.Context as PopperContext;

        public PopperContextBuilder() : base(new PopperContext())
        {
        }

        public PopperContextBuilder WithOpen(bool open)
        {
            PContext.Open = open;

            return this;
        }

        public PopperContextBuilder WithOnEnter(Func<(IReference, bool), Task> onEnter)
        {
            PContext.OnEnter = onEnter;

            return this;
        }

        public PopperContextBuilder WithOnExited(Func<IReference, Task> onExited)
        {
            PContext.OnExited = onExited;

            return this;
        }

        public override PopperContextBuilder With(IPopperContext context)
        {
            base.With(context)
            .WithOpen(context.Open)
            .WithRefBack(context.RefBack)
            .WithOnEnter(context.OnEnter)
            .WithOnExited(context.OnExited);

            return this;
        }

        protected override PopperContextBuilder This()
        {
            return this;
        }
    }
}