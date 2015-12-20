// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.batches")]
    [PrimaryKey("batch_id", AutoIncrement = true)]
    public sealed class Batch : IPoco
    {
        public int BatchId { get; set; }
        public string BatchCode { get; set; }
        public string BatchName { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
        public int CourseId { get; set; }
        public bool IsActive { get; set; }
        public int TotalSemester { get; set; }
        public bool IsDeleted { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}