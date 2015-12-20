// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.blood_groups")]
    [PrimaryKey("blood_group_id", AutoIncrement = true)]
    public sealed class BloodGroup : IPoco
    {
        public int BloodGroupId { get; set; }
        public string BloodGroupCode { get; set; }
        public string BloodGroupName { get; set; }
        public bool IsDeleted { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime AuditTs { get; set; }
    }
}