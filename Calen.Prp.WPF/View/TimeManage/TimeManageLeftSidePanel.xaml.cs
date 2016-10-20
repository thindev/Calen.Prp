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
    /// TimeManageLeftSidePanel.xaml 的交互逻辑
    /// </summary>
    public partial class TimeManageLeftSidePanel : UserControl
    {
        public TimeManageLeftSidePanel()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            this.ExpandMenuPanel();
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.CollapseMenuPanel();
        }

        void ExpandMenuPanel()
        {
            if (this.tagsToggleButton != null)
                this.tagsToggleButton.Visibility = Visibility.Collapsed;
            this.rightColumn.Width = new GridLength(160);
            if(this.activitiesContainer!=null)
            this.activitiesContainer.Visibility = Visibility.Visible;
        }
        void CollapseMenuPanel()
        {
            if(tagsToggleButton!=null)
            {
                this.tagsToggleButton.Visibility = Visibility.Visible;
            }
           
            this.rightColumn.Width = new GridLength(0);
            if(this.activitiesContainer!=null)
            this.activitiesContainer.Visibility = Visibility.Collapsed;
        }
    }
}
