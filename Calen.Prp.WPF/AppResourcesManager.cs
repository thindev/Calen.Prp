using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calen.Prp.WPF
{
    public static class AppResourcesManager
    {
        public static T GetResource<T>(object resourceKey)
        {
            if(Application.Current!=null)
            {
                return (T)Application.Current.FindResource(resourceKey);
            }
            else
            {
                return default(T);
            }
        }
    }
}
