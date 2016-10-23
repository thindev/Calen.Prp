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
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class GoalManageViewModel : ViewModelBase<GoalEditList>
    {
        public GoalManageViewModel(GoalEditList model) : base(model)
        {
            model.CollectionChanged += Model_CollectionChanged;
            BufferGoalItem = new GoalViewModel(GoalEditList.NewGoalChild());
        }

        private void Model_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Application.Current?.Dispatcher.BeginInvoke(new Action(delegate()
            {
                List<string> goalIds = _goalList.Select(g => g.Model.Id).ToList();
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (GoalEdit g in e.NewItems)
                    {
                        if (!goalIds.Contains(g.Id))
                        {
                            _goalList.Add(new GoalViewModel(g));
                        }
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (GoalEdit g in e.OldItems)
                    {
                        if (goalIds.Contains(g.Id))
                        {
                            GoalViewModel item = _goalList.First(x => x.Model.Id == g.Id);
                            _goalList.Remove(item);
                        }
                    }
                }
            }));
            
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
        public ICommand AddGoalCommand
        {
            get
            {
                if(_addGoalCommand==null)
                {
                    _addGoalCommand = new RelayCommand(AddGoalAtion);
                }
                return _addGoalCommand;
            }
        }
        public ICommand SubmitEditCommand
        {
            get
            {
                if(_submitEditCommand==null)
                {
                    _submitEditCommand = new RelayCommand(SubmitEditAction);
                }
                return _submitEditCommand;
            }
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

        public bool IsGoalDetialPanelShowed
        {
            get
            {
                return _isEditModel||_isViewDetailMode;
            }

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
                    RaisePropertyChanged(() => IsGoalDetialPanelShowed);
                }
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
                    RaisePropertyChanged(() => IsGoalDetialPanelShowed);
                }
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
                if (CurrentEditingItem != null)
                {
                    IsEditModel = true;
                }
            }
        }

        GoalViewModel _currentEditingItem;

        private async void AddGoalAsync(bool keepEditingMode)
        {
            this.IsBusy = true;
            await Model.AddGoalAsync(this.BufferGoalItem.Model);
            this.IsBusy = false;
            GoalViewModel newBuffer=new GoalViewModel(GoalEditList.NewGoalChild());
            if (this.BufferGoalItem == this.CurrentEditingItem)
            {
                this.CurrentEditingItem = this.BufferGoalItem = newBuffer;
            }
            else
            {
                this.BufferGoalItem = newBuffer;
            }
            if(!keepEditingMode)
            this.IsEditModel = false;
            
        }
        private async void SubmitGoalEditingAsync()
        {
            this.IsBusy = true;
           await this.Model.SubmitGoalEditAsync(this.CurrentEditingItem.Model);
            this.IsBusy = false;
        }

    }
}
