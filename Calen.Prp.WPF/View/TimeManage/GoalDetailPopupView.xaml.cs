﻿using System;
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
    /// GoalDetailPopupView.xaml 的交互逻辑
    /// </summary>
    public partial class GoalDetailPopupView : UserControl
    {
        public GoalDetailPopupView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HdtPopup popup=this.Parent as HdtPopup;
            if(popup!=null)
            {
                popup.IsOpen = false;
            }
        }
    }
}
