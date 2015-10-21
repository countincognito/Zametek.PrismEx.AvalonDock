using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel.Composition;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    [ModuleExport(typeof(TestAppModule))]
    public class TestAppModule
       : IModule
    {
        #region Fields

        private readonly IRegionManager m_RegionManager;

        #endregion

        #region Ctors

        [ImportingConstructor]
        public TestAppModule(IRegionManager regionManager)
        {
            if (regionManager == null)
            {
                throw new ArgumentNullException("regionManager");
            }
            m_RegionManager = regionManager;
        }

        #endregion

        #region IModule Members

        public void Initialize()
        {
            m_RegionManager.RegisterViewWithRegion("MainRegion", typeof(BottomAnchorableView));
            m_RegionManager.RegisterViewWithRegion("MainRegion", typeof(RightAnchorableView));
            m_RegionManager.RegisterViewWithRegion("MainRegion", typeof(LeftAnchorableView));
        }

        #endregion
    }
}
