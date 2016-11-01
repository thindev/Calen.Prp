using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Csla;
using SQLite.Net;
using Calen.Prp.Dal;
using Calen.Prp.Dal.Tables;

namespace Calen.Prp.Core.TimeManage
{
    [Serializable]
    public class GoalEdit:BusinessBase<GoalEdit>
    {
        public static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(p => p.Id);
        public static readonly PropertyInfo<string> ParentGoalIdProperty = RegisterProperty<string>(p => p.ParentGoalId);
        public static readonly PropertyInfo<string> ContentProperty = RegisterProperty<string>(p => p.Content);
        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(p=>p.Description);

        

        public static readonly PropertyInfo<DateTime> StartTimeProperty = RegisterProperty<DateTime>(p => p.StartTime);
        public static readonly PropertyInfo<DateTime> EndTimeProperty = RegisterProperty<DateTime>(p => p.EndTime);
        public static readonly PropertyInfo<int> LevelProperty = RegisterProperty<int>(p => p.Level);
        public static readonly PropertyInfo<CommentEditList> CommentListProperty = RegisterProperty<CommentEditList>(p => p.CommentList);
        public static readonly PropertyInfo<bool> IsAchievedProperty = RegisterProperty<bool>(p => p.IsAchieved);
        public string Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public string ParentGoalId
        {
            get { return GetProperty(ParentGoalIdProperty); }
            set { SetProperty(ParentGoalIdProperty, value); }
        }
        public string Content
        {
            get { return GetProperty(ContentProperty); }
            set { SetProperty(ContentProperty, value); }
        }
        
        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }
        public DateTime StartTime
        {
            get { return GetProperty(StartTimeProperty); }
            set { SetProperty(StartTimeProperty, value); }
        }
        public DateTime EndTime
        {
            get { return GetProperty(EndTimeProperty); }
            set { SetProperty(EndTimeProperty, value); }
        }
        public int Level
        {
            get { return GetProperty(LevelProperty); }
            set { SetProperty(LevelProperty, value); }
        }

        public CommentEditList CommentList
        {
            get { return GetProperty(CommentListProperty); }
            set { SetProperty(CommentListProperty, value); }
        }

        public bool IsAchieved
        {
            get { return GetProperty(IsAchievedProperty); }
            set
            {
                SetProperty(IsAchievedProperty, value);
            }
        }

        public static GoalEdit New()
        {
            GoalEdit goal = DataPortal.Create<GoalEdit>();
            goal.Id = Guid.NewGuid().ToString();
            goal.StartTime = DateTime.Now;
            goal.EndTime = goal.StartTime.AddDays(7);
            goal.Level = 1;
            return goal;
        }
       
        internal static GoalEdit FromDbItem(Goal item)
        {
            GoalEdit ge = DataPortal.Fetch<GoalEdit>();
            ge.Id = item.Id;
            ge.Content = item.Content;
            ge.Description = item.Description;
            ge.EndTime = item.EndTime;
            ge.IsAchieved = item.IsAchieved;
            ge.Level = item.Level;
            ge.ParentGoalId = item.ParentGoalId;
            ge.StartTime = item.StartTime;
            ge.MarkClean();
            return ge;
        }
        protected void DataPortal_Fetch()
        {

        }



        protected override void DataPortal_Insert()
        {
            Goal item = this.ToDbItem();
            item.CreateTime =item.LastUpdateTime= DateTime.Now;
            DataAccessor.Instance.DataBase.Insert(item);
        }
        protected override void DataPortal_Update()
        {
            Goal item = this.ToDbItem();
            item.LastUpdateTime = DateTime.Now;
            DataAccessor.Instance.DataBase.Update(item);
        }
        protected override void DataPortal_DeleteSelf()
        {
            Goal item = this.ToDbItem();
            DataAccessor.Instance.DataBase.Delete(item);
        }


        protected Goal ToDbItem()
        {

            Goal item=null;
            if (IsNew)
                item = new Goal();
            else
                DataAccessor.Instance.DataBase.Find<Goal>(this.Id);
            item.Content = this.Content;
            item.Description = this.Description;
            item.EndTime = this.EndTime;
            item.Id = this.Id;
            item.IsAchieved = this.IsAchieved;
            item.Level = this.Level;
            item.ParentGoalId = this.ParentGoalId;
            item.StartTime = this.StartTime;
            return item;
        }



    }
}
