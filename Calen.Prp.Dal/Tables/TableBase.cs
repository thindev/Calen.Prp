using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.Prp.Dal.Tables
{
   public class TableBase
    {
        [PrimaryKey, Column("_id"), MaxLength(32)]
        public string Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
