using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// StarLevelIndenticator.xaml 的交互逻辑
    /// </summary>
    public partial class StarLevelIndicator : UserControl
    {
        public static readonly DependencyProperty MaxLevelProperty = DependencyProperty.Register("MaxLevel", typeof(int), typeof(StarLevelIndicator), new PropertyMetadata(3,new PropertyChangedCallback(MaxLevelChanged)));
        public int MaxLevel
        {
            get
            {
                return (int) GetValue(MaxLevelProperty);
            }
            set
            {
                SetValue(MaxLevelProperty,value);
            }
        }
        private static void MaxLevelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StarLevelIndicator indicator = (StarLevelIndicator)d;
            int level = (int)e.NewValue;
           
        }

        private void CreatStars(int maxLevel)
        {
            this._starList.Clear();
            this.root.Children.Clear();
            for (int i = 0; i < maxLevel; i++)
            {
                ToggleButton btn = new ToggleButton();
                btn.Style = (Style)this.FindResource("ToggleButtonStyle_Star");
                this.root.Children.Add(btn);
                this._starList.Add(btn);
                //btn.Checked += this.Btn_Checked;
                //btn.Unchecked += this.Btn_Unchecked;
            }
        }

        private  void Btn_Unchecked(object sender, RoutedEventArgs e)
        {
           int index=  this._starList.IndexOf((ToggleButton)sender);
            for(int i=index;i<this._starList.Count;i++)
            {
                this._starList[index].IsChecked = false;
            }
        }

        private  void Btn_Checked(object sender, RoutedEventArgs e)
        {
            int index = this._starList.IndexOf((ToggleButton)sender);
            for (int i = 0; i < index; i++)
            {
                this._starList[index].IsChecked = true;
            }
        }

        List<ToggleButton> _starList = new List<ToggleButton>();

        public StarLevelIndicator()
        {
            InitializeComponent();
            if(this.MaxLevel!=0)
            {
                this.CreatStars(this.MaxLevel);
            }
        }
    }
}
