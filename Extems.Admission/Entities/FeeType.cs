// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Admission.Entities
{
    [TableName("admission.fee_types")]
    [PrimaryKey("fee_type_id", AutoIncrement = true)]
    public sealed class FeeType : IPoco
    {
        public int FeeTypeId { get; set; }
        public string FeeTypeCode { get; set; }
        public string FeeTypeName { get; set; }
        public long? TransactionGlAccountId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}