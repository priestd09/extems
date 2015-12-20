// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.sections")]
    [PrimaryKey("section_id", AutoIncrement = true)]
    public sealed class Section : IPoco
    {
        public int SectionId { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }
        public int OfficeId { get; set; }
        public int BatchId { get; set; }
        public bool IsDeleted { get; set; }
        public int AuditUserId { get; set; }
        public DateTime AuditTs { get; set; }
    }
}