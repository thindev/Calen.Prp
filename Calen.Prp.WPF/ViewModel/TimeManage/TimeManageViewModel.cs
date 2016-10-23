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
        bool _isGoalMenuSelected;
        bool _isCalendarMenuSelected;
        bool _isTimeTableMenuSelected;
        bool _isToDoListMenuSelected;
        bool _isDiaryMenuSelected;
        string _currentTitle;
        ObservableCollection<ActivityViewModel> _activities = new ObservableCollection<ActivityViewModel>();
        ActivityViewModel _currentActivity;


        public TimeManageViewModel()
        {
            _goalManager = new GoalManageViewModel(new Core.TimeManage.GoalEditList());
        }

        public bool IsGoalMenuSelected
        {
            get
            {
                return _isGoalMenuSelected;
            }

            set
            {
                if(value)
                {
                    this.CurrentTitle = "目标";
                }
                Set(() => IsGoalMenuSelected, ref _isGoalMenuSelected, value);
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
                    this.CurrentTitle = "我的日历";
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
                    this.CurrentTitle = "事项列表";
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
                if(_currentActivity!=value)
                {
                    if (value != null)
                    {
                        this.CurrentTitle = "["+value.Name+"]的待办事项";
                    }
                    _currentActivity = value;
                    RaisePropertyChanged(()=>CurrentActivity);
                }
            }
        }

        public bool IsDiaryMenuSelected
        {
            get
            {
                return _isDiaryMenuSelected;
            }

            set
            {
                if(value)
                {
                    this.CurrentTitle = "日记";
                }
                Set(() => IsDiaryMenuSelected,ref _isDiaryMenuSelected,value);
            }
        }

        GoalManageViewModel _goalManager;
        public GoalManageViewModel GoalManager
        {
            get { return _goalManager; }
            //set { Set(() => GoalManager, ref _goalManager, value); }
        }
    }
}
