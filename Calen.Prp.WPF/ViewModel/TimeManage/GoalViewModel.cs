using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Calen.Prp.Core.TimeManage;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class GoalViewModel : ViewModelBase<GoalEdit>
    {
        public GoalViewModel(GoalEdit model) : base(model)
        {
        }
    }
}
