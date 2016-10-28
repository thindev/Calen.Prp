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
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class GoalManageViewModel : ViewModelBase<GoalDynamicList>
    {
        ListCollectionView _defaultCollectionView;
        public GoalManageViewModel(GoalDynamicList model) : base(model)
        {
            model.CollectionChanged += Model_CollectionChanged;
            this.GoalList.CollectionChanged += GoalList_CollectionChanged;
            this.InitData();
            //设置排序、分组描述
            this.SetListDescription();
        }

        private void GoalList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void Model_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Application.Current?.Dispatcher.Invoke(new Action(() => {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        {
                            List<GoalEdit> goals = this.GoalList.Select(x => x.Model).ToList();
                            foreach (GoalEdit g in e.NewItems)
                            {
                                if (!goals.Contains(g))
                                {
                                    GoalViewModel vm = new GoalViewModel(g);
                                    this.GoalList.Add(vm);
                                }
                            }
                            break;
                        }
                    case NotifyCollectionChangedAction.Remove:
                        {
                            List<GoalEdit> goals = this.GoalList.Select(x => x.Model).ToList();
                            foreach (GoalEdit g in e.OldItems)
                            {
                                if (goals.Contains(g))
                                {
                                   GoalViewModel vm= this.GoalList.First(x=>x.Model==g);
                                    this.GoalList.Remove(vm);
                                }
                            }
                            break;
                        }
                    
                }
            }));
        }
       

        void InitData()
        {
            BufferGoalItem = new GoalViewModel(GoalEdit.NewGoalEdit());
        }

        void SetListDescription()
        {
            _defaultCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(this.GoalList);
            SortDescription sd = new SortDescription();
            sd.PropertyName = "Model.Level";
            sd.Direction = ListSortDirection.Descending;
            SortDescription sd1 = new SortDescription() { PropertyName = "Model.EndTime", Direction = ListSortDirection.Ascending };
            SortDescription sd2 = new SortDescription() { PropertyName = "Model.IsAchieved", Direction = ListSortDirection.Ascending };
            _defaultCollectionView.SortDescriptions.Add(sd2);
            _defaultCollectionView.SortDescriptions.Add(sd);
            _defaultCollectionView.SortDescriptions.Add(sd1);
            _defaultCollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Model.IsAchieved"));
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
        ICommand _deleteSelectedItemCommand;
        public ICommand DeleteSelectedItemCommand
        {
            get
            {
                if(_deleteSelectedItemCommand==null)
                {
                    _deleteSelectedItemCommand = new RelayCommand<GoalViewModel>(DeleteSelectedItemAction);
                }
                return _deleteSelectedItemCommand;
            }
        }

        private async void DeleteSelectedItemAction(GoalViewModel obj)
        {
            if(obj==null)
            {
                obj = this.CurrentEditingItem;
                if (obj == null)
                    return;
            }
            this.IsBusy = true;
            obj.Model.Delete();
            await obj.SaveAsync();
            this.IsBusy = false;
            this.GoalList.Remove(obj);

        }

        public ICommand ShowSelectedItemDetailCommand
        {
            get
            {
                if(_showSelectedItemDetailCommand==null)
                {
                    _showSelectedItemDetailCommand = new RelayCommand<GoalViewModel>(ShowDetailAction);
                }
                return _showSelectedItemDetailCommand;
            }
        }

        private void ShowDetailAction(GoalViewModel goal)
        {
            if (goal != null)
                this.CurrentEditingItem = goal;
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
            this.GoalList.Add(this.BufferGoalItem);
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
            _defaultCollectionView.EditItem(this.CurrentEditingItem);
            await this.CurrentEditingItem.SaveAsync();
            this.IsBusy = false;
            this.IsEditModel = false;
            this.IsGoalDetialPanelShowed = false;
            _defaultCollectionView.CommitEdit();
        }


    }
}
