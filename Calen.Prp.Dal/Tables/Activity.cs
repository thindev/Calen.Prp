using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.Prp.Dal.Tables
{
    [Table("Activity")]
    public class Activity:TableBase
    {
        public string Name { get; set; }
        public string CreatorId { get; set; }
    }
}
