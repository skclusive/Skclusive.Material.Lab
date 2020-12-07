using System;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Button;
using Skclusive.Material.Icon;
using Skclusive.Material.Paper;
using Skclusive.Material.Typography;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Alert
{
    public static class AlertExtension
    {
        public static void TryAddAlertServices(this IServiceCollection services, IMaterialConfig config, AlertPaletteConfig light = null, AlertPaletteConfig dark = null)
        {
            services.TryAddButtonServices(config);

            services.TryAddIconServices(config);

            services.TryAddPaperServices(config);

            services.TryAddTypographyServices(config);

            services.TryAddStyleTypeProvider<AlertStyleProvider>();

            // services.TryAddStyleProducer<AlertStyleProducer>();

            // TODO: would be removed once integrated with Material.Component
            services.TryAddStyleProducer<AlertStyleProducer>(sp => new AlertStyleProducer(light, dark));
        }

        // TODO: would be removed once integrated with Material.Component
        public static void TryAddStyleProducer<TStyleProducer>(this IServiceCollection services, Func<IServiceProvider, TStyleProducer> implementationFactory) where TStyleProducer : class, IStyleProducer
        {
            services.TryAddScopedEnumerable<IStyleProducer, TStyleProducer>(implementationFactory);
        }
    }
}
