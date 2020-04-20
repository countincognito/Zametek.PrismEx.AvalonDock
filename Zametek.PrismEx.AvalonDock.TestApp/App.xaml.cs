using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Windows;
using Xceed.Wpf.AvalonDock;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    public partial class App
        : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<BottomAnchorableView>();
            containerRegistry.RegisterForNavigation<DocumentView>("DocumentView");
            containerRegistry.RegisterSingleton<LeftAnchorableView>();
            containerRegistry.RegisterSingleton<RightAnchorableView>();
            containerRegistry.RegisterSingleton<ShellView>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<TestAppModule>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);


            
            regionAdapterMappings.RegisterMapping(typeof(SelectorRegionAdapter), Container.Resolve<SelectorRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(DockingManager), Container.Resolve<DockingManagerRegionAdapter>());
        }
    }
}
