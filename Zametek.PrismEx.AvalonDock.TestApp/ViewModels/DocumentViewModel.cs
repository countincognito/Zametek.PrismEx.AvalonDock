using Prism.Mvvm;
using Prism.Regions;
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

        private string m_Name;

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
                return Name;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            private set
            {
                m_Name = value;
                OnPropertyChanged(() => Title);
                OnPropertyChanged(() => Name);
            }
        }

        #endregion

        #region INavigationAware Members

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            if (navigationContext == null)
            {
                throw new ArgumentNullException("navigationContext");
            }
            var name = navigationContext.Parameters["Name"] as string;
            if (!string.IsNullOrEmpty(name))
            {
                return string.Compare(name, Name, StringComparison.OrdinalIgnoreCase) == 0;
            }
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
            Name = navigationContext.Parameters["Name"] as string;
        }

        #endregion
    }
}
