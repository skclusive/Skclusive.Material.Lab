using Skclusive.Core.Component;

namespace Skclusive.Material.Tooltip
{
    public class TooltipStyleProvider : StyleTypeProvider
    {
        public TooltipStyleProvider() : base(priority: 300, typeof(TooltipStyle))
        {
        }
    }
}