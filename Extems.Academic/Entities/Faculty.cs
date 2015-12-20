// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.faculties")]
    [PrimaryKey("faculty_id", AutoIncrement = true)]
    public sealed class Faculty : IPoco
    {
        public int FacultyId { get; set; }
        public string FacultyCode { get; set; }
        public string FacultyName { get; set; }
        public bool IsDeleted { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}