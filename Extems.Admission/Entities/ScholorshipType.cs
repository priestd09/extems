// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Admission.Entities
{
    [TableName("admission.scholorship_types")]
    [PrimaryKey("scholorship_type_id", AutoIncrement = true)]
    public sealed class ScholorshipType : IPoco
    {
        public int ScholorshipTypeId { get; set; }
        public string ScholorshipTypeCode { get; set; }
        public string ScholorshipTypeName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidTill { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}