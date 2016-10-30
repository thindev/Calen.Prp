using Calen.Prp.Core.TimeManage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class ActivityManageViewModel : ViewModelBase<ActivityDynamicList>
    {
        ObservableCollection<ActivityViewModel> _activityList = new ObservableCollection<ActivityViewModel>();
        public ObservableCollection<ActivityViewModel> ActivityList
        {
            get { return _activityList; }
        }
        public ActivityManageViewModel(ActivityDynamicList model) : base(model)
        {
            this.RefreshListAsync();
        }

        protected async void RefreshListAsync()
        {
            ActivityDynamicList list=null;
            await Task.Run(() =>
            {
                list = ActivityDynamicList.Fetch();
            }
            );
            foreach(ActivityEdit activity in list)
            {
                ActivityViewModel vm = new ActivityViewModel(activity);
                _activityList.Add(vm);
            }
        }
    }
}
