using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Calen.Prp.WPF.View
{
    public class SlidePanel:UserControl
    {
        public static readonly DependencyProperty IsOpenedProperty = DependencyProperty.Register("IsOpened", typeof(bool), typeof(SlidePanel), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(IsOpenedChanged)));
        public static readonly DependencyProperty ExpandedWidthProperty = DependencyProperty.Register("ExpandedWidth", typeof(double), typeof(SlidePanel),new FrameworkPropertyMetadata(60.0,new PropertyChangedCallback(ExpandedWidthChanged)));

        private static void ExpandedWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SlidePanel sp = (SlidePanel)d;
            double value = (double)e.NewValue;
            sp._expandAnimation.To = value;
        }

        public bool IsOpened
        {
            get { return (bool)GetValue(IsOpenedProperty); }
            set { SetValue(IsOpenedProperty,value); }
        }
        public double ExpandedWidth
        {
            get { return (double)GetValue(ExpandedWidthProperty); }
            set { SetValue(ExpandedWidthProperty, value); }
        }
        private static void IsOpenedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SlidePanel sp = (SlidePanel)d;
            bool isOpened = (bool)e.NewValue;
            if(isOpened)
            {
                sp.Expand();
            }
            else
            {
                sp.Collapse();
            }
        }

        DoubleAnimation _expandAnimation;
        DoubleAnimation _collapseAnimation;
        public SlidePanel()
        {
            Duration d = new Duration(TimeSpan.FromMilliseconds(500));
            _expandAnimation = new DoubleAnimation();
            _expandAnimation.To = this.ExpandedWidth;
            _expandAnimation.Duration = d;
            _collapseAnimation = new DoubleAnimation();
            _collapseAnimation.To = 0;
            _collapseAnimation.Duration = d;
            _collapseAnimation.EasingFunction= _expandAnimation.EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseInOut };
            _collapseAnimation.Completed += _collapseAnimation_Completed;
            if(!IsOpened)
            {
                this.Visibility = Visibility.Collapsed;
                this.Width = 0;
            }
        }

        private void _collapseAnimation_Completed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        void Expand()
        {
            this.Visibility = Visibility.Visible;
            this.BeginAnimation(WidthProperty, _expandAnimation);
        }
        void Collapse()
        {
            this.BeginAnimation(WidthProperty, _collapseAnimation);
        }
    }
}
