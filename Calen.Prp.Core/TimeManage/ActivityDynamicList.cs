using Calen.Prp.Dal;
using Calen.Prp.Dal.Tables;
using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calen.Prp.Core.TimeManage
{
    [Serializable]
    public class ActivityDynamicList : DynamicListBase<ActivityEdit>
    {
        public static ActivityDynamicList Fetch()
        {
            return DataPortal.Fetch<ActivityDynamicList>();
        }
        protected override void DataPortal_Fetch(object criteria)
        {
            List<Activity> activities = DataAccessor.Instance.DataBase.Table<Activity>().ToList();
            foreach (var item in activities)
            {
                ActivityEdit ae = ActivityEdit.FromDbItem(item);
                this.Add(ae);
            }
        }
    }
}
