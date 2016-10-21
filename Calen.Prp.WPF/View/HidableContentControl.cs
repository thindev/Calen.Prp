using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Markup;

namespace Calen.Prp.WPF.View
{
    [ContentProperty("HidableContent")]
    public class HidableContentControl : MahApps.Metro.Controls.TransitioningContentControl
    {
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(HidableContentControl), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(IsSelectedPropertyChangedCallback)));
        public static readonly DependencyProperty HidableContentProperty = DependencyProperty.Register("HidableContent", typeof(object), typeof(HidableContentControl), new PropertyMetadata(null, new PropertyChangedCallback(HidableContentChanged)));

        private static void HidableContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HidableContentControl control = (HidableContentControl)d;
            if(control.IsSelected)
            {
                control.Content = e.NewValue;
            }
        }

        private static void IsSelectedPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HidableContentControl control = (HidableContentControl)d;
            bool visible = (bool)e.NewValue;
            if (visible)
            {
                control.Show();
            }
            else
            {
                control.Hide();
            }
        }
       
        public HidableContentControl()
        {
            this.Transition = MahApps.Metro.Controls.TransitionType.Left;
        }

        public object HidableContent
        {
            get
            {
                return (object)GetValue(HidableContentProperty);
            }
            set
            {
                base.SetValue(HidableContentProperty, value);
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
            this.Content = this.HidableContent;
        }
        private void Hide()
        {
            this.Content = null;
        }
    }
}
