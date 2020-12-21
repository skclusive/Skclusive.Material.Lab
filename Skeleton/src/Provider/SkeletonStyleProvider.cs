using Skclusive.Core.Component;

namespace Skclusive.Material.Skeleton
{
    public class SkeletonStyleProvider : StyleTypeProvider
    {
        public SkeletonStyleProvider() : base(priority: 300, typeof(SkeletonStyle))
        {
        }
    }
}