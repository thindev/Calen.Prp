using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Csla;
using Calen.Prp.Dal;
using Calen.Prp.Dal.Tables;
using SQLite.Net;
using System.Linq;

namespace Calen.Prp.Core.TimeManage
{
    [Serializable]
    public class GoalDynamicList : DynamicListBase<GoalEdit>
    {
        public static GoalDynamicList Fetch()
        {
           return DataPortal.Fetch<GoalDynamicList>();
        }
        protected override void DataPortal_Fetch(object criteria)
        {
            List<Goal> goals = DataAccessor.Instance.DataBase.Table<Goal>().Where(item => true).ToList();
            foreach(var item in goals)
            {
                GoalEdit ge = GoalEdit.FromDbItem(item);
                this.Add(ge);
            }
        }
    }
}
