using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class ActivityViewModel:ViewModelBase
    {
        string _id;
        string _name;

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                Set(() => Id, ref _id, value);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                Set(() => Name, ref _name, value);
            }
        }
    }
}
