// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.subjects")]
    [PrimaryKey("subject_id", AutoIncrement = true)]
    public sealed class Subject : IPoco
    {
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int CourseId { get; set; }
        public int? Semester { get; set; }
        public int TotalWeeklyClasses { get; set; }
        public int CreditHours { get; set; }
        public decimal FullMark { get; set; }
        public decimal PassMark { get; set; }
        public bool IsDeleted { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}