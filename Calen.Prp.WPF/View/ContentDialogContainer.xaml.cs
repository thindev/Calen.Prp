using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calen.Prp.WPF.View
{
    /// <summary>
    /// ContentDialogContainer.xaml 的交互逻辑
    /// </summary>
    public partial class ContentDialogContainer : UserControl
    {
        public ContentDialogContainer()
        {
            InitializeComponent();
            this.Visibility = Visibility.Collapsed;
        }
        public void Show()
        {
            this.Visibility = Visibility.Visible;
        }
        public void Hide()
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
