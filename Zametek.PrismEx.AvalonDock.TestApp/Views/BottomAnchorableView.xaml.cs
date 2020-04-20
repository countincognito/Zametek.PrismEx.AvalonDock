using System;
using System.ComponentModel.Composition;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    [AvalonDockAnchorable(Strategy = AnchorableStrategy.Bottom, IsHidden = true)]
    public partial class BottomAnchorableView
    {
        #region Ctors

        [ImportingConstructor]
        public BottomAnchorableView(
            BottomAnchorableViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }

            InitializeComponent();
            ViewModel = viewModel;
        }

        #endregion

        #region Properties

        public BottomAnchorableViewModel ViewModel
        {
            get
            {
                return DataContext as BottomAnchorableViewModel;
            }
            set
            {
                if (ViewModel != value)
                {
                    DataContext = value;
                }
            }
        }

        #endregion
    }
}
