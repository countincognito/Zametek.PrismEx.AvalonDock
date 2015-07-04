using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xceed.Wpf.AvalonDock.Layout;
using Zametek.Utility;

namespace Zametek.PrismEx.AvalonDock
{
    public class DockingManagerRegionAdapterLayoutStrategy
       : ILayoutUpdateStrategy
    {
        private ILayoutUpdateStrategy m_WrappedStrategy = new EmptyDockingManagerRegionAdapterLayoutStrategy();

        public DockingManagerRegionAdapterLayoutStrategy()
        {
        }

        public DockingManagerRegionAdapterLayoutStrategy(ILayoutUpdateStrategy wrappedStrategy)
        {
            if (wrappedStrategy != null)
            {
                m_WrappedStrategy = wrappedStrategy;
            }
        }

        #region ILayoutUpdateStrategy Members

        public void AfterInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableShown)
        {
            m_WrappedStrategy.AfterInsertAnchorable(layout, anchorableShown);
        }

        public void AfterInsertDocument(LayoutRoot layout, LayoutDocument anchorableShown)
        {
            m_WrappedStrategy.AfterInsertDocument(layout, anchorableShown);
        }

        public bool BeforeInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableToShow, ILayoutContainer destinationContainer)
        {
            bool result = false;
            if (layout != null
               && anchorableToShow != null)
            {
                var destPane = destinationContainer as LayoutAnchorablePane;
                if (anchorableToShow.Root == null)
                {
                    anchorableToShow.AddToLayout(layout.Manager, GetContentAnchorableStrategy(anchorableToShow));
                    result = true;
                }
                else
                    if (destPane != null && anchorableToShow.IsHidden)
                    {
                        // Show a hidden Anchorable.
                        if (anchorableToShow.PreviousContainerIndex < 0)
                        {
                            destPane.Children.Add(anchorableToShow);
                        }
                        else
                        {
                            int insertIndex = anchorableToShow.PreviousContainerIndex;
                            if (insertIndex > destPane.ChildrenCount)
                            {
                                insertIndex = destPane.ChildrenCount;
                            }
                            destPane.Children.Insert(insertIndex, anchorableToShow);
                        }
                        result = true;
                    }
            }
            return result || m_WrappedStrategy.BeforeInsertAnchorable(layout, anchorableToShow, destinationContainer);
        }

        public bool BeforeInsertDocument(LayoutRoot layout, LayoutDocument anchorableToShow, ILayoutContainer destinationContainer)
        {
            return m_WrappedStrategy.BeforeInsertDocument(layout, anchorableToShow, destinationContainer);
        }

        #endregion

        private static AnchorableShowStrategy GetContentAnchorableStrategy(LayoutAnchorable anchorable)
        {
            var anchorableStrategy = AnchorableStrategies.Most;
            if (anchorable != null)
            {
                if (anchorable.IsAnchorable())
                {
                    anchorableStrategy = anchorable.GetAnchorableStrategy();
                }
                else
                    if (anchorable.Content.IsAnchorable())
                    {
                        anchorableStrategy = anchorable.Content.GetAnchorableStrategy();
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
            }

            AnchorableShowStrategy flag = 0;
            foreach (AnchorableStrategies strategyFlag in SplitAnchorableStrategies(anchorableStrategy))
            {
                var strategy = AnchorableShowStrategy.Most;
                strategyFlag.ValueSwitchOn()
                   .Case(AnchorableStrategies.Most,
                         x => strategy = AnchorableShowStrategy.Most)
                   .Case(AnchorableStrategies.Left,
                         x => strategy = AnchorableShowStrategy.Left)
                   .Case(AnchorableStrategies.Right,
                         x => strategy = AnchorableShowStrategy.Right)
                   .Case(AnchorableStrategies.Top,
                         x => strategy = AnchorableShowStrategy.Top)
                   .Case(AnchorableStrategies.Bottom,
                         x => strategy = AnchorableShowStrategy.Bottom)
                   .Default(x =>
                   {
                       throw new InvalidEnumArgumentException("Unknown AnchorableStrategy value");
                   });
                flag |= strategy;
            }
            if (flag == 0)
            {
                flag = AnchorableShowStrategy.Most;
            }
            return flag;
        }

        private static AnchorableStrategies[] SplitAnchorableStrategies(AnchorableStrategies strategy)
        {
            var returnArray = new List<AnchorableStrategies>();
            foreach (var value in Enum.GetValues(typeof(AnchorableStrategies)).Cast<AnchorableStrategies>())
            {
                if (strategy.HasFlag(value))
                {
                    returnArray.Add(value);
                }
            }
            return returnArray.ToArray();
        }

        #region Private Types

        private class EmptyDockingManagerRegionAdapterLayoutStrategy
           : ILayoutUpdateStrategy
        {
            public void AfterInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableShown)
            {
            }

            public void AfterInsertDocument(LayoutRoot layout, LayoutDocument anchorableShown)
            {
            }

            public bool BeforeInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableToShow, ILayoutContainer destinationContainer)
            {
                return false;
            }

            public bool BeforeInsertDocument(LayoutRoot layout, LayoutDocument anchorableToShow, ILayoutContainer destinationContainer)
            {
                return false;
            }
        }

        #endregion
    }
}
