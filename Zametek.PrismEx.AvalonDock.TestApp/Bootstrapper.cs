using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;
using Xceed.Wpf.AvalonDock;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    public class Bootstrapper
       : MefBootstrapper, IDisposable
    {
        #region Fields

        private bool m_Disposed;

        #endregion

        #region Ctors

        public Bootstrapper()
        {
            m_Disposed = false;
        }

        #endregion

        #region Internal Static Methods

        internal static void HandleException(Exception ex)
        {
            if (ex == null)
            {
                return;
            }
            // Would normally have a service here rather than just MessageBox.
            MessageBox.Show(ex.ToString());
            Environment.Exit(1);
        }

        #endregion

        #region MefBootstrapper Overrides

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return base.CreateModuleCatalog();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            return base.ConfigureDefaultRegionBehaviors();
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(
                typeof(DockingManager),
                new DockingManagerRegionAdapter(ServiceLocator.Current.GetInstance<IRegionBehaviorFactory>()));
            return mappings;
        }

        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<ShellView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (ShellView)Shell;
            App.Current.MainWindow.Show();
        }

        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
            Application.Current.MainWindow.Activate();
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (m_Disposed)
            {
                return;
            }
            if (disposing)
            {
                // Free any other managed objects here. 
            }

            // Free any unmanaged objects here. 

            m_Disposed = true;
        }

        #endregion
    }
}
