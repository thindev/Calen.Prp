using Calen.Prp.Dal;
using Calen.Prp.Dal.Tables;
using Csla;
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

        internal static ActivityEdit FromDbItem(Activity item)
        {
            ActivityEdit ae = DataPortal.Fetch<ActivityEdit>();
            ae.Name = item.Name;
            ae.Id = item.Id;
            ae.Description = item.Description;
            ae.MarkClean();
            return ae;
        }
        protected override void DataPortal_Insert()
        {
            Activity item = ToDbItem();
            item.CreateTime = item.LastUpdateTime = DateTime.Now;
            DataAccessor.Instance.DataBase.Insert(item);
        }
       
        protected override void DataPortal_Update()
        {
            Activity item = ToDbItem();
            item.LastUpdateTime = DateTime.Now;
            DataAccessor.Instance.DataBase.Update(item);
        }
        public void MarkIdle1()
        {
            this.MarkIdle();
        }
       
        internal  Activity ToDbItem()
        {
            Activity a = null;
            if (IsNew)
                a = new Activity();
            else
            a = DataAccessor.Instance.DataBase.Find<Activity>(this.Id);
            a.Description = this.Description;
            a.Id = this.Id;
            a.Name = this.Name;
            return a;
        }
        protected override void DataPortal_DeleteSelf()
        {
            Activity item = ToDbItem();
            DataAccessor.Instance.DataBase.Delete(item);
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
