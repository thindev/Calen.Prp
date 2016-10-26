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
        public static readonly DependencyProperty CurrentLevelProperty = DependencyProperty.Register("CurrentLevel", typeof(int), typeof(StarLevelIndicator), new PropertyMetadata(1, new PropertyChangedCallback(CurrentLevelChanged)));

        private static void CurrentLevelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StarLevelIndicator indicator = (StarLevelIndicator)d;
            int level = (int)e.NewValue;
            indicator.SetLevel(level);
        }

        public int CurrentLevel
        {
            get
            {
                return (int)GetValue(CurrentLevelProperty);
            }
            set
            {
                SetValue(CurrentLevelProperty,value);
            }
        }

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
            indicator.CreatStars(level);
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
                btn.Click += this.Btn_Click;
            }
        }
        void SetLevel(int level)
        {
            for(int i=0;i<this._starList.Count;i++)
            {
                if (i < this.CurrentLevel)
                    this._starList[i].IsChecked = true;
                else
                    this._starList[i].IsChecked = false;
            }
        }

        private  void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.CurrentLevel == 1 && sender == _starList[0])
            {
                foreach(ToggleButton tgb in _starList)
                {
                    tgb.IsChecked = false;
                }
            }
            else
            {
                int index = this._starList.IndexOf((ToggleButton)sender);
                for (int i = 0; i < this._starList.Count; i++)
                {
                    if (i <= index)
                        this._starList[i].IsChecked = true;
                    else
                        this._starList[i].IsChecked = false;
                }
            }
            this.CurrentLevel = _starList.Where(x => x.IsChecked.Value).Count();
           
        }

       

        List<ToggleButton> _starList = new List<ToggleButton>();

        public StarLevelIndicator()
        {
            InitializeComponent();
            if(this.MaxLevel>0)
            {
                this.CreatStars(this.MaxLevel);
                this.SetLevel(this.CurrentLevel);
            }
           
        }
    }
}
