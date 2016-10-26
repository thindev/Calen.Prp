using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Calen.Prp.Core.TimeManage;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class GoalViewModel : ViewModelBase<GoalEdit>
    {
        static int i = 0;
        public GoalViewModel(GoalEdit model) : base(model)
        {
            T = i++;
        }

        public int T { get; set; }
        ICommand _saveCommand;
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
