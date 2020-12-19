using System;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Typography;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Tooltip
{
    public static class TooltipExtension
    {
        public static void TryAddTooltipServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddTypographyServices(config);

            services.TryAddStyleTypeProvider<TooltipStyleProvider>();

            services.TryAddStyleProducer<TooltipStyleProducer>();
        }
    }
}
