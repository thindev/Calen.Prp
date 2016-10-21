using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.Prp.WPF.ViewModel
{
    public class Class1<T>:ObservableCollection<T>
    {
        private new  void  Add(T item)
        {
            base.Add(item);
        }
    }
}
