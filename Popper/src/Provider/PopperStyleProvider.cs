using Skclusive.Core.Component;

namespace Skclusive.Material.Popper
{
    public class PopperStyleProvider : StyleTypeProvider
    {
        public PopperStyleProvider() : base(priority: 250, typeof(PopperStyle))
        {
        }
    }
}