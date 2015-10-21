using Prism.Events;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using Zametek.WindowsEx.AvalonDock;

namespace Zametek.PrismEx.AvalonDock.TestApp
{
    [Export]
    public partial class ShellView
    {
        #region Fields

        private readonly LeftAnchorableView m_LeftAnchorableView;
        private readonly BottomAnchorableView m_BottomAnchorableView;
        private readonly RightAnchorableView m_RightAnchorableView;

        #endregion

        #region Ctors

        [ImportingConstructor]
        public ShellView(
            LeftAnchorableView leftAnchorableView,
            BottomAnchorableView bottomAnchorableView,
            RightAnchorableView rightAnchorableView,
            ShellViewModel viewModel,
            IEventAggregator eventService)
        {
            if (leftAnchorableView == null)
            {
                throw new ArgumentNullException("leftAnchorableView");
            }
            if (bottomAnchorableView == null)
            {
                throw new ArgumentNullException("bottomAnchorableView");
            }
            if (rightAnchorableView == null)
            {
                throw new ArgumentNullException("rightAnchorableView");
            }
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }
            if (eventService == null)
            {
                throw new ArgumentNullException("eventService");
            }
            m_LeftAnchorableView = leftAnchorableView;
            m_BottomAnchorableView = bottomAnchorableView;
            m_RightAnchorableView = rightAnchorableView;
            ViewModel = viewModel;
            InitializeComponent();
        }

        #endregion

        #region Properties

        public ShellViewModel ViewModel
        {
            get
            {
                return DataContext as ShellViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        #endregion

        #region ShowLeftAnchorable

        private void ShowLeftAnchorableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowLeftAnchorable();
        }

        private void ShowLeftAnchorable()
        {
            DockManager.ShowAnchorable(m_LeftAnchorableView);
        }

        #endregion

        #region ShowBottomAnchorable

        private void ShowBottomAnchorableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowBottomAnchorable();
        }

        private void ShowBottomAnchorable()
        {
            DockManager.ShowAnchorable(m_BottomAnchorableView);
        }

        #endregion

        #region ShowRightAnchorable

        private void ShowRightAnchorableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowRightAnchorable();
        }

        private void ShowRightAnchorable()
        {
            DockManager.ShowAnchorable(m_RightAnchorableView);
        }

        #endregion

        #region Overrides

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            bool allClosed = DockManager.CloseAllDocuments();

            // Perhaps one of the documents isn't ready to close yet.
            e.Cancel = !allClosed;
        }

        #endregion
    }
}
