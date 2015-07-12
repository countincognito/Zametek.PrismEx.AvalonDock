using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using System;
using System.ComponentModel.Composition;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class DocumentViewModel
       : BindableBase, INavigationAware
    {
        #region Fields

        private string m_Title;

        #endregion

        #region Ctors

        public DocumentViewModel()
        {
        }

        #endregion

        #region Properties

        public string Title
        {
            get
            {
                return m_Title;
            }
            private set
            {
                m_Title = value;
                OnPropertyChanged(() => Title);
            }
        }

        #endregion

        #region INavigationAware Members

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext == null)
            {
                throw new ArgumentNullException("navigationContext");
            }
            Title = navigationContext.Parameters["Name"] as string;
        }

        #endregion
    }
}
