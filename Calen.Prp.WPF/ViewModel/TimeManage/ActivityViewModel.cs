using Calen.Prp.Core.TimeManage;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.Prp.WPF.ViewModel.TimeManage
{
    public class ActivityViewModel:ViewModelBase<ActivityEdit>
    {

        public ActivityViewModel(ActivityEdit model) : base(model)
        {

        }
        public void BeginEdit()
        {
            this.Model.BeginEdit();
        }
        public void CancelEdit()
        {
            this.Model.CancelEdit();
        }
        public void ApplyEdit()
        {
            this.Model.ApplyEdit();
            this.Model.MarkNotBusy();
        }
        public async Task SaveAsync()
        {
            this.Model=await this.Model.SaveAsync();
        }
    }
}
