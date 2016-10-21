using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.Prp.Dal.Tables
{
    [Table("Goal")]
    public class Goal
    {
        [PrimaryKey,Column("_id"),MaxLength(32)]
        public string Id { get; set; }
        public string ParentGoalId { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Level { get; set; }
        
    }
}
