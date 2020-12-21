using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Button;
using Skclusive.Material.Paper;
using Skclusive.Material.Transition;

namespace Skclusive.Material.Accordion
{
    public static class AccordionExtension
    {
        public static void TryAddAccordionServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddPaperServices(config);

            services.TryAddButtonServices(config);

            services.TryAddMaterialTransitionServices(config);

            services.TryAddStyleTypeProvider<AccordionStyleProvider>();
        }
    }
}
