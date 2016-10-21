using Calen.Prp.Core.TimeManage;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class GoalManageViewModel : ViewModelBase<GoalEditList>
    {
        public GoalManageViewModel(GoalEditList model) : base(model)
        {
            model.
        }

        ObservableCollection<GoalEdit> _goalList = new ObservableCollection<GoalEdit>();

        public ObservableCollection<GoalEdit> GoalList
        {
            get
            {
                return _goalList;
            }
        }
    }
}
