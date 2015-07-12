using System;
using System.Windows;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    public partial class App
        : IDisposable
    {
        #region Fields

        private readonly Bootstrapper m_Bootstrapper;
        private bool m_Disposed;

        #endregion

        #region Ctors

        public App()
        {
            m_Bootstrapper = new Bootstrapper();
        }

        #endregion

        #region Private Methods

        private void RunApplication()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            try
            {
                m_Bootstrapper.Run();
            }
            catch (Exception ex)
            {
                Bootstrapper.HandleException(ex);
            }
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Bootstrapper.HandleException(e.ExceptionObject as Exception);
        }

        #endregion

        #region Overrides

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RunApplication();
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
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
                m_Bootstrapper.Dispose();
            }

            // Free any unmanaged objects here. 

            m_Disposed = true;
        }

        #endregion
    }
}
