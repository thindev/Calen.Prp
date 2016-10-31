using System.Windows;
using Calen.Prp.WPF.ViewModel;
using System.Windows.Controls;
using Calen.Prp.WPF.View;

namespace Calen.Prp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            AppContext.DialogHelper = new DialogHelper();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            FrameworkElement fe = (FrameworkElement)base.GetVisualChild(0);
            Grid grid = fe as Grid;
            ContentDialogContainer cdc = new ContentDialogContainer();
            grid.Children.Add(cdc);
            DialogHelper.SetContentDialogContainer(this, cdc);
        } 
    }
}