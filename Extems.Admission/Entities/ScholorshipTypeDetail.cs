// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Admission.Entities
{
    [TableName("admission.scholorship_type_details")]
    [PrimaryKey("scholorship_type_detail_id", AutoIncrement = true)]
    public sealed class ScholorshipTypeDetail : IPoco
    {
        public int ScholorshipTypeDetailId { get; set; }
        public int ScholorshipTypeId { get; set; }
        public int FeeTypeId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}