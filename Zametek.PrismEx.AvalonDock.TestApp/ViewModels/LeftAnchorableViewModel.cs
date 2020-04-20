﻿using Prism.Mvvm;
using Prism.Regions;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    public sealed class LeftAnchorableViewModel
       : BindableBase, INavigationAware
    {
        #region Ctors

        public LeftAnchorableViewModel()
        {
            Title = "Left Anchorable ViewModel";
        }

        #endregion

        #region Properties

        public string Title
        {
            get;
            private set;
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
        }

        #endregion
    }
}
