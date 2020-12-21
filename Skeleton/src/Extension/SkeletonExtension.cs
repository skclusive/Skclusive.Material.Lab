using System;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Skeleton
{
    public static class SkeletonExtension
    {
        public static void TryAddSkeletonServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddMaterialCoreServices(config);

            services.TryAddStyleTypeProvider<SkeletonStyleProvider>();

            services.TryAddStyleProducer<SkeletonStyleProducer>();
        }
    }
}
