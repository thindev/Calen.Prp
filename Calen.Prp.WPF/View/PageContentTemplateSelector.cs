using Calen.Prp.WPF.ViewModel;
using Calen.Prp.WPF.ViewModel.TimeManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calen.Prp.WPF.View
{
    public class PageContentTemplateSelector:DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate template= null; 
            if (item is TimeManageViewModel)
            {
                template = Application.Current.FindResource("TimeManagePageTemplateKey")as DataTemplate;
            }
            else
            template= base.SelectTemplate(item, container);
            return template;
        }
    }
}
