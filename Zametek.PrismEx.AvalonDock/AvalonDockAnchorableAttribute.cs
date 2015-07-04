using System;

namespace Zametek.PrismEx.AvalonDock
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class AvalonDockAnchorableAttribute
       : Attribute
    {
        public AnchorableStrategies Strategy
        {
            get;
            set;
        }
    }
}
