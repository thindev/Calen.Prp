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

        internal static ActivityEdit FromDbItem(Activity item)
        {
            ActivityEdit ae = DataPortal.Fetch<ActivityEdit>();
            ae.Name = item.Name;
            ae.Id = item.Id;
            ae.MarkClean();
            return ae;
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
