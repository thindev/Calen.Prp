using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Csla;

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

       public static GoalEdit NewGoalEdit()
        {
            GoalEdit goal = DataPortal.Create<GoalEdit>();
            goal.Id = Guid.NewGuid().ToString();
            goal.StartTime = DateTime.Now;
            goal.EndTime = goal.StartTime.AddDays(7);
            return goal;
        }

      

    }
}
