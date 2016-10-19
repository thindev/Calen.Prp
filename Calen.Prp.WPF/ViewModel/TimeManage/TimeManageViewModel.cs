using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class TimeManageViewModel:ViewModelBase
    {
        bool _isTargetMenuSelected;
        bool _isCalendarMenuSelected;
        bool _isTimeTableMenuSelected;
        bool _isToDoListMenuSelected;
        string _currentTitle;
        ObservableCollection<ActivityViewModel> _activities = new ObservableCollection<ActivityViewModel>();
        ActivityViewModel _currentActivity;

        public bool IsTargetMenuSelected
        {
            get
            {
                return _isTargetMenuSelected;
            }

            set
            {
                if(value)
                {
                    this.CurrentTitle = "目标列表";
                }
                Set(() => IsTargetMenuSelected, ref _isTargetMenuSelected, value);
            }
        }

        public bool IsCalendarMenuSelected
        {
            get
            {
                return _isCalendarMenuSelected;
            }

            set
            {
               if(value)
                {
                    this.CurrentTitle = "日历";
                }
                Set(() => IsCalendarMenuSelected, ref _isCalendarMenuSelected, value);
            }
        }

        public bool IsTimeTableMenuSelected
        {
            get
            {
                return _isTimeTableMenuSelected;
            }

            set
            {
                if (value)
                {
                    this.CurrentTitle = "作息表";
                }
                Set(() => IsTimeTableMenuSelected, ref _isTimeTableMenuSelected, value);
            }
        }

        public bool IsToDoListMenuSelected
        {
            get
            {
                return _isToDoListMenuSelected;
            }

            set
            {
                if(value)
                {
                    this.CurrentTitle = "待办事项";
                }
                Set(() => IsToDoListMenuSelected, ref _isToDoListMenuSelected, value);
            }
        }

        public string CurrentTitle
        {
            get
            {
                return _currentTitle;
            }

            set
            {
                Set(() => CurrentTitle, ref _currentTitle, value);
            }
        }

        public ObservableCollection<ActivityViewModel> Activities
        {
            get
            {
                return _activities;
            }
        }

        public ActivityViewModel CurrentActivity
        {
            get
            {
                return _currentActivity;
            }

            set
            {
                Set(()=> CurrentActivity, ref _currentActivity, value);
            }
        }
    }
}
