using Calen.Prp.Core.TimeManage;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class ActivityViewModel:ViewModelBase<ActivityEdit>
    {
        string _id;
        string _name;

        public ActivityViewModel(ActivityEdit model) : base(model)
        {

        }
    }
}
