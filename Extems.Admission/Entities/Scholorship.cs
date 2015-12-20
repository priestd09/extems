// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Admission.Entities
{
    [TableName("admission.scholorships")]
    [PrimaryKey("scholorship_id", AutoIncrement = true)]
    public sealed class Scholorship : IPoco
    {
        public long ScholorshipId { get; set; }
        public long AdmissionApplicationId { get; set; }
        public int ScholorshipTypeId { get; set; }
        public DateTime? LastVerifiedOn { get; set; }
        public int? VerifiedByUserId { get; set; }
        public short VerificationStatusId { get; set; }
        public string VerificationReason { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}