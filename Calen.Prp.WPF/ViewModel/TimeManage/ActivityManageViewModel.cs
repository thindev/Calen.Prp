using Calen.Prp.Core.TimeManage;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class ActivityManageViewModel : ViewModelBase<ActivityDynamicList>
    {
        ObservableCollection<ActivityViewModel> _activityList = new ObservableCollection<ActivityViewModel>();
        ActivityViewModel _currentEditingItem;
        ActivityViewModel _selectedItem;
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
        ICommand _addActivityCommand;
        ICommand _cancelCurrentEditCommand;
        ICommand _submitCurrentEditCommand;
        ICommand _deleteSelectedItemCommand;
        ICommand _beginEditSelectedItemCommand;
        public ICommand BeginEditSelectedItemCommand
        {
            get
            {
                return _beginEditSelectedItemCommand ?? (_beginEditSelectedItemCommand = new RelayCommand<ActivityViewModel>(BeginEditSelectedItemAction));
            }
        }

        private void BeginEditSelectedItemAction(ActivityViewModel obj)
        {
            if (obj == null)
            {
                obj = this.SelectedItem;
                if (obj == null)
                    return;
            }
            obj.BeginEdit();
            this.CurrentEditingItem = obj;
            AppContext.DialogHelper.ShowContentDialog(this, this);

        }

        public ICommand DeleteSelectedItemCommand
        {
            get
            {
                if (_deleteSelectedItemCommand == null)
                {
                    _deleteSelectedItemCommand = new RelayCommand<ActivityViewModel>(DeleteSelectedItemAction);
                }
                return _deleteSelectedItemCommand;
            }
        }

        private async void DeleteSelectedItemAction(ActivityViewModel obj)
        {
            if (obj == null)
            {
                obj = this.CurrentEditingItem;
                if (obj == null)
                    return;
            }
            this.IsBusy = true;
            obj.Model.Delete();
            await obj.SaveAsync();
            this.IsBusy = false;
            this.ActivityList.Remove(obj);

        }
        public ICommand SubmitCurrentEditCommand
        {
            get
            {
                return _submitCurrentEditCommand ?? (_submitCurrentEditCommand=new RelayCommand(SubmitCurrentEditAction));
            }
        }

        private async void SubmitCurrentEditAction()
        {
            bool isNew = this.CurrentEditingItem.Model.IsNew;
            this.CurrentEditingItem.ApplyEdit();
            this.IsBusy = true;
            await this.CurrentEditingItem.SaveAsync();
            this.IsBusy = false;
            AppContext.DialogHelper.RemoveContentDialog(this);
            if(isNew)
            this.ActivityList.Add(this.CurrentEditingItem);
            this.CurrentEditingItem = null;
        }

        public ICommand CancelCurrentEditCommand
        {
            get
            {
                return _cancelCurrentEditCommand ?? (_cancelCurrentEditCommand=new RelayCommand(CancelCurrentEditAction));
            }
        }

        private void CancelCurrentEditAction()
        {
            this.CurrentEditingItem.CancelEdit();
            AppContext.DialogHelper.RemoveContentDialog(this);
            this.CurrentEditingItem = null;
        }

        public ICommand AddActivityCommand
        {
            get { return _addActivityCommand ?? (_addActivityCommand = new RelayCommand(AddActivityAction)); }
        }

        public ActivityViewModel CurrentEditingItem
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

        public ActivityViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                Set(() => SelectedItem, ref _selectedItem, value);
            }
        }

        private void AddActivityAction()
        {
            CurrentEditingItem = new ActivityViewModel(ActivityEdit.New());
            AppContext.DialogHelper.ShowContentDialog(this,this);
            this.CurrentEditingItem.BeginEdit();
        }
    }
}
