using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using System.Threading.Tasks;

namespace Calen.Prp.Core.TimeManage
{
    [Serializable]
    public class GoalEditList:BusinessListBase<GoalEditList,GoalEdit>
    {
        public static GoalEditList NewGoalEditList()
        {
            GoalEditList goalList = DataPortal.Create<GoalEditList>();
            return goalList;
        }
        public async Task<GoalEdit> AddGoalAsync(GoalEdit goal)
        {
            GoalEdit ge = await DataPortal.UpdateAsync<GoalEdit>(goal);
            this.Add(ge);
            return ge;
        }

        public async Task<GoalEdit> SubmitGoalEditAsync(GoalEdit goal)
        {
            GoalEdit ge = await DataPortal.UpdateAsync<GoalEdit>(goal);
            return goal;
        }

        public static GoalEdit NewGoalChild()
        {
            GoalEdit goal = DataPortal.CreateChild<GoalEdit>();
            goal.Id = Guid.NewGuid().ToString();
            return goal;
        }
    }
}
