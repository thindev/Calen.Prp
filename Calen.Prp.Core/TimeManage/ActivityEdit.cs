using Calen.Prp.Dal;
using Calen.Prp.Dal.Tables;
using Csla;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.Prp.Core.TimeManage
{
    [Serializable]
    public class ActivityEdit:BusinessBase<ActivityEdit>
    {
        public static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(p => p.Id);
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(p => p.Name);
        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(p => p.Description);
        public static readonly PropertyInfo<string> GroupNameProperty = RegisterProperty<string>(p => p.GroupName);

        public string Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }

        public string GroupName
        {
            get { return GetProperty(GroupNameProperty); }
            set { SetProperty(GroupNameProperty, value); }
        }

        internal static ActivityEdit FromDbItem(Activity item)
        {
            ActivityEdit ae = DataPortal.Fetch<ActivityEdit>();
            ae.Name = item.Name;
            ae.Id = item.Id;
            ae.Description = item.Description;
            ae.GroupName = item.GroupName;
            ae.MarkClean();
            return ae;
        }
        protected override void DataPortal_Insert()
        {
            using (SQLiteConnection con = DataAccessor.Instance.GetDbConnection())
            {
                Activity item = ToDbItem();
                item.CreateTime = item.LastUpdateTime = DateTime.Now;
                con.Insert(item);
            }
        }
       
        protected override void DataPortal_Update()
        {
            using (SQLiteConnection con = DataAccessor.Instance.GetDbConnection())
            {
                Activity item = ToDbItem();
                item.LastUpdateTime = DateTime.Now;
                con.Update(item);
            }
        }
        public void MarkIdle1()
        {
            this.MarkIdle();
        }
       
        internal  Activity ToDbItem()
        {
            using (SQLiteConnection con = DataAccessor.Instance.GetDbConnection())
            {
                Activity a = null;
                if (IsNew)
                    a = new Activity();
                else
                    a = con.Find<Activity>(this.Id);
                a.Description = this.Description;
                a.Id = this.Id;
                a.Name = this.Name;
                a.GroupName = this.GroupName;
                return a;
            }
        }
        protected override void DataPortal_DeleteSelf()
        {
            using (SQLiteConnection con = DataAccessor.Instance.GetDbConnection())
            {
                Activity item = ToDbItem();
                con.Delete(item);
            }
        }
        protected void DataPortal_Fetch()
        {

        }

        public static ActivityEdit New()
        {
          ActivityEdit ae=  DataPortal.Create<ActivityEdit>();
            ae.Id = Guid.NewGuid().ToString();
            return ae;
        }
    }
}
