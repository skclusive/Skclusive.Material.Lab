using Skclusive.Core.Component;

namespace Skclusive.Material.Popper
{
    public class PopperScriptProvider : ScriptTypeProvider
    {
        public PopperScriptProvider() : base(priority: 250, typeof(PopperScript))
        {
        }
    }
}