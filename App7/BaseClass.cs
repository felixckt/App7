using System;
using SQLite;

namespace hr.AEON
{
    [Table("Attendance")]
    public class clockin
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string staffid { get; set; }
        public DateTime clockInTime { get; set; }
    }
}