// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Admission.Entities
{
    [TableName("admission.admissions")]
    [PrimaryKey("admission_id", AutoIncrement = true)]
    public sealed class Admission : IPoco
    {
        public long AdmissionId { get; set; }
        public long AdmissionApplicationId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int OfficeId { get; set; }
        public int BatchId { get; set; }
        public int ClassId { get; set; }
        public int? HouseId { get; set; }
        public bool IsActive { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}