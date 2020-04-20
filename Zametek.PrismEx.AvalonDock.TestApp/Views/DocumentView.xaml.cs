using System;
using System.ComponentModel.Composition;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    public partial class DocumentView
    {
        #region Ctors

        [ImportingConstructor]
        public DocumentView(
            DocumentViewModel viewModel)
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

        public DocumentViewModel ViewModel
        {
            get
            {
                return DataContext as DocumentViewModel;
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
