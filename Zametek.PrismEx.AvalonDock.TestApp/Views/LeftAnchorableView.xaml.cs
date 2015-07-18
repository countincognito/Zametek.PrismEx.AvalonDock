using System;
using System.ComponentModel.Composition;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [AvalonDockAnchorable(Strategy = AnchorableStrategy.Left, IsHidden = true)]
    public partial class LeftAnchorableView
    {
        #region Ctors

        [ImportingConstructor]
        public LeftAnchorableView(
            LeftAnchorableViewModel viewModel)
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

        public LeftAnchorableViewModel ViewModel
        {
            get
            {
                return DataContext as LeftAnchorableViewModel;
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
