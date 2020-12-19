using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;
using Skclusive.Material.Paper;

namespace Skclusive.Material.Popper
{
    public static class PopperExtension
    {
        public static void TryAddPopperServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddPaperServices(config);

            services.TryAddModalServices(config);

            services.TryAddTransient<PopperHelper>();

            services.TryAddStyleTypeProvider<PopperStyleProvider>();

            services.TryAddScriptTypeProvider<PopperScriptProvider>();
        }
    }
}
