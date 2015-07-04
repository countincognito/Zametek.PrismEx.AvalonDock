using System;
using System.Linq;

namespace Zametek.PrismEx.AvalonDock
{
    public static class AvalonDockAnchorableAttributeExtensions
    {
        public static bool IsAnchorable(this object obj)
        {
            return obj.GetAvalonDockAnchorableAttribute() != null;
        }

        public static AnchorableStrategies GetAnchorableStrategy(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            var avalonDockAnchorableAttribute = obj.GetAvalonDockAnchorableAttribute();
            if (avalonDockAnchorableAttribute == null)
            {
                throw new InvalidOperationException();
            }
            return avalonDockAnchorableAttribute.Strategy;
        }

        public static AvalonDockAnchorableAttribute GetAvalonDockAnchorableAttribute(this object obj)
        {
            return obj.GetType().GetCustomAttributes(typeof(AvalonDockAnchorableAttribute), true).FirstOrDefault() as AvalonDockAnchorableAttribute;
        }
    }
}
