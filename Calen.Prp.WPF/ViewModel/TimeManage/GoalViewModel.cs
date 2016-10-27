using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Calen.Prp.Core.TimeManage;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class GoalViewModel : ViewModelBase<GoalEdit>
    {
        public GoalViewModel(GoalEdit model) : base(model)
        {
           
        }

        ICommand _saveCommand;
        ICommand _changeGoalStateCommand;
        public ICommand ChangeGoalStateCommand
        {
            get
            {
                if(_changeGoalStateCommand==null)
                {
                    _changeGoalStateCommand = new RelayCommand<ObservableCollection<GoalViewModel>>(ChangeGoalStateAction);
                }
                return _changeGoalStateCommand;
            }
        }

        private async void ChangeGoalStateAction(ObservableCollection<GoalViewModel> collection)
        {
            this.Model.IsAchieved = !this.Model.IsAchieved;
            ListCollectionView view =(ListCollectionView) CollectionViewSource.GetDefaultView(collection);
            if(view!=null)
            {
                view.EditItem(this);
                await this.SaveAsync();
                view.CommitEdit();
            }
            else
            {
                await this.SaveAsync();
            }

        }

        public ICommand SaveCommand
        {
            get
            {
                if(_saveCommand==null)
                {
                    _saveCommand = new RelayCommand(SaveAciton);
                }
                return _saveCommand;
            }
        }

        private void SaveAciton()
        {
           
        }
        public async Task<GoalViewModel> SaveAsync()
        {
            this.IsBusy = true;
            this.Model = await this.Model.SaveAsync();
            this.IsBusy = false;
            return this;
        }
    }
}
