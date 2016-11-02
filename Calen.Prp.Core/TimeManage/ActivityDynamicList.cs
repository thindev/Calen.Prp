using Calen.Prp.Dal;
using Calen.Prp.Dal.Tables;
using Csla;
using SQLite.Net;
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
        public static string[] GetActivityGroupNames()
        {
            using (SQLiteConnection con = DataAccessor.Instance.GetDbConnection())
            {
                string[] names = con.Table<Activity>().Select(i => i.GroupName).Distinct().ToArray();
                return names;
            }
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            using (SQLiteConnection con = DataAccessor.Instance.GetDbConnection())
            {
                List<Activity> activities = con.Table<Activity>().ToList();
                foreach (var item in activities)
                {
                    ActivityEdit ae = ActivityEdit.FromDbItem(item);
                    this.Add(ae);
                }
            }
        }
    }
}
