using Prism.Regions;
using System;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace Zametek.PrismEx.AvalonDock
{
    public class DockingManagerRegionAdapter
       : RegionAdapterBase<DockingManager>
    {
        public DockingManagerRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {
            if (region == null)
            {
                throw new ArgumentNullException("region");
            }
            if (regionTarget == null)
            {
                throw new ArgumentNullException("regionTarget");
            }

            ILayoutUpdateStrategy currentLayoutStrategy = regionTarget.LayoutUpdateStrategy;
            regionTarget.LayoutUpdateStrategy = new DockingManagerRegionAdapterLayoutStrategy(currentLayoutStrategy);

            // Add the behavior that synchronizes the items source items with the rest of the items.
            region.Behaviors.Add(
               DockingManagerLayoutContentSyncBehavior.BehaviorKey,
               new DockingManagerLayoutContentSyncBehavior(regionTarget));
            base.AttachBehaviors(region, regionTarget);
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
