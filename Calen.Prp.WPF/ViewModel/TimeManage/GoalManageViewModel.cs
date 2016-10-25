using Calen.Prp.Core.TimeManage;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class GoalManageViewModel : ViewModelBase<GoalEditManager>
    {
        public GoalManageViewModel(GoalEditManager model) : base(model)
        {
            BufferGoalItem = new GoalViewModel(GoalEdit.NewGoalEdit());
        }

        ObservableCollection<GoalViewModel> _goalList = new ObservableCollection<GoalViewModel>();

        public ObservableCollection<GoalViewModel> GoalList
        {
            get
            {
                return _goalList;
            }
        }

        ICommand _createGoalCommand;
        ICommand _cancelEditCommand;
        ICommand _addGoalCommand;
        ICommand _submitEditCommand;
        ICommand _showSelectedItemDetailCommand;
        public ICommand ShowSelectedItemDetailCommand
        {
            get
            {
                if(_showSelectedItemDetailCommand==null)
                {
                    _showSelectedItemDetailCommand = new RelayCommand(ShowDetailAction);
                }
                return _showSelectedItemDetailCommand;
            }
        }

        private void ShowDetailAction()
        {
            this.IsEditModel = true;
            this.IsGoalDetialPanelShowed = true;
        }

        public ICommand AddGoalCommand
        {
            get
            {
                if(_addGoalCommand==null)
                {
                    _addGoalCommand = new  RelayCommand(AddGoalAtion,AddGoalPredicate);
                }
                return _addGoalCommand;
            }
        }

        private bool AddGoalPredicate()
        {
            bool value= (this.BufferGoalItem!=null&&!string.IsNullOrEmpty(this.BufferGoalItem.Model.Content));
            return value;
        }

        public ICommand SubmitEditCommand
        {
            get
            {
                if(_submitEditCommand==null)
                {
                    _submitEditCommand = new RelayCommand(SubmitEditAction,SubmitPredicate);
                }
                return _submitEditCommand;
            }
        }

        private bool SubmitPredicate()
        {
            bool value = (this.CurrentEditingItem != null && !string.IsNullOrEmpty(this.CurrentEditingItem.Model.Content));
            return value;
        }

        private void SubmitEditAction()
        {
            if(this.CurrentEditingItem==this.BufferGoalItem)
            {
                this.AddGoalAsync(false);
            }
            else
            {
                this.SubmitGoalEditingAsync();
            }
        }

       

        private void AddGoalAtion()
        {

            this.AddGoalAsync(true);
        }

        public ICommand CanelEditCommand
        {
            get
            {
                if (_cancelEditCommand == null)
                {
                    _cancelEditCommand = new RelayCommand(CancelEditAction, CancelGoalPredicate);
                }
                return _cancelEditCommand;
            }
        }

        private bool CancelGoalPredicate()
        {
            return true;
        }

        private void CancelEditAction()
        {
            this.IsEditModel = false;
        }

        public ICommand CreateGoalCommand
        {
            get
            {
                if(_createGoalCommand==null)
                {
                    _createGoalCommand = new RelayCommand(CreateGoalAction,CreateGoalPredicate);
                }
                return _createGoalCommand;
            }
        }

        bool _isGoalDetialPanelShowed;
        public bool IsGoalDetialPanelShowed
        {
            get
            {
                return _isGoalDetialPanelShowed;
            }
            set { Set(() => IsGoalDetialPanelShowed, ref _isGoalDetialPanelShowed, value); }
        }

        private bool CreateGoalPredicate()
        {
            return true;
        }

        private void CreateGoalAction()
        {
            this.CurrentEditingItem = this.BufferGoalItem;
            this.IsEditModel = true;
        }


        bool _isEditModel;
        public bool IsEditModel
        {
            get { return _isEditModel; }
            set
            {
                if(_isEditModel!=value)
                {
                    _isEditModel = value;
                    RaisePropertyChanged(()=>IsEditModel);
                }
                if (value)
                    IsGoalDetialPanelShowed = value;
            }
        }
        bool _isViewDetailMode;
        public bool IsViewDetailMode
        {
            get { return _isViewDetailMode; }
            set
            {
                if(_isViewDetailMode!=value)
                {
                    _isViewDetailMode = value;
                    RaisePropertyChanged(() => IsViewDetailMode);
                   
                }
                if (value)
                    IsGoalDetialPanelShowed = value;
            }
        }

        GoalViewModel _bufferGoalItem;
        public GoalViewModel BufferGoalItem
        {
            get { return _bufferGoalItem; }
            set { Set(() => BufferGoalItem, ref _bufferGoalItem, value); }
        }

        public GoalViewModel CurrentEditingItem
        {
            get
            {
                return _currentEditingItem;
            }

            set
            {
               
                    Set(() => CurrentEditingItem, ref _currentEditingItem, value);
            }
        }
        GoalViewModel _currentEditingItem;

        /// <summary>
        /// 异步新增一条记录
        /// </summary>
        /// <param name="keepEditingMode"></param>
        private async void AddGoalAsync(bool keepEditingMode)
        {
            this.IsBusy = true;
            this.BufferGoalItem= await this.BufferGoalItem.SaveAsync();
            this.GoalList.Insert(0,this.BufferGoalItem);
            this.IsBusy = false;
            GoalViewModel newBuffer=new GoalViewModel(GoalEdit.NewGoalEdit());
            if (this.BufferGoalItem == this.CurrentEditingItem)
            {
                this.CurrentEditingItem = this.SelectedGoal;
            }
            this.BufferGoalItem = newBuffer;

            if (this.CurrentEditingItem == null)
            {
                this.IsEditModel = false;
                this.IsGoalDetialPanelShowed = false;
            }
        }

        GoalViewModel _selectedGoal;
        public GoalViewModel SelectedGoal
        {
            get { return _selectedGoal; }
            set
            {
                this.CurrentEditingItem = value;
                this._selectedGoal = value;
                RaisePropertyChanged(()=>SelectedGoal);
            }
        }

        /// <summary>
        /// 异步提交编辑结果
        /// </summary>
        private async void SubmitGoalEditingAsync()
        {
            this.IsBusy = true;
            await this.CurrentEditingItem.SaveAsync();
            this.IsBusy = false;
            this.IsEditModel = false;
            this.IsGoalDetialPanelShowed = false;
        }


    }
}
