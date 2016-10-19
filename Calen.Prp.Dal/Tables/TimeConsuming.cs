using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.Prp.Dal.Tables
{
    /// <summary>
    /// 耗时的，所有需要消耗时间的类都继承此类
    /// </summary>
    class TimeConsuming
    {
        public DateTime PlanedStartTime { get; set; }
        public DateTime ActualStartTime { get; set; }
        public DateTime PlanedFinishTime { get; set; }
        public DateTime ActualFinishTime { get; set; }
        /// <summary>
        /// 计划花费时间（秒）
        /// </summary>
        public double PlanedTimeCost { get; set; }
       
    }
}
