using System;
using System.ComponentModel.Composition;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [AvalonDockAnchorable(Strategy = AnchorableStrategy.Right, IsHidden = true)]
    public partial class RightAnchorableView
    {
        #region Ctors

        [ImportingConstructor]
        public RightAnchorableView(
            RightAnchorableViewModel viewModel)
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

        public RightAnchorableViewModel ViewModel
        {
            get
            {
                return DataContext as RightAnchorableViewModel;
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
