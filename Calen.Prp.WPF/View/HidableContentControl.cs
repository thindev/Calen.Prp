using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Calen.Prp.WPF.View
{
    public class HidableContentControl:ContentControl
    {
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(HidableContentControl), new FrameworkPropertyMetadata(true,new PropertyChangedCallback(IsSelectedPropertyChangedCallback)));

        private static void IsSelectedPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HidableContentControl control = (HidableContentControl)d;
            bool visible = (bool)e.NewValue;
            if(visible)
            {
                control.Show();
            }
            else
            {
                control.Hide();
            }
        }
        public bool IsSelected
        {
            get
            {
                return (bool)base.GetValue(IsSelectedProperty);
            }
            set
            {
                base.SetValue(IsSelectedProperty, value);
            }
        }

        private void Show()
        {
            this.Visibility = Visibility.Visible;
        }
        private void Hide()
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
