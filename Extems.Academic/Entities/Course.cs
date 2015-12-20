// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.courses")]
    [PrimaryKey("course_id", AutoIncrement = true)]
    public sealed class Course : IPoco
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int FacultyId { get; set; }
        public int AcademicLevelId { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool AllowMultipleAdmission { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}