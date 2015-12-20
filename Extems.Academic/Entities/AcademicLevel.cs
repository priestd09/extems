// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.academic_levels")]
    [PrimaryKey("academic_level_id", AutoIncrement = true)]
    public sealed class AcademicLevel : IPoco
    {
        public int AcademicLevelId { get; set; }
        public string AcademicLevelCode { get; set; }
        public string AcademicLevelName { get; set; }
        public bool IsDeleted { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}