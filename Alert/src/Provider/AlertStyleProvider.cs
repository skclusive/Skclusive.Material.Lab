using Skclusive.Core.Component;

namespace Skclusive.Material.Alert
{
    public class AlertStyleProvider : StyleTypeProvider
    {
        public AlertStyleProvider() : base(priority: 300, typeof(AlertStyle), typeof(AlertTitleStyle))
        {
        }
    }
}