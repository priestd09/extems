// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.houses")]
    [PrimaryKey("house_id", AutoIncrement = true)]
    public sealed class House : IPoco
    {
        public int HouseId { get; set; }
        public string HouseCode { get; set; }
        public string HouseName { get; set; }
        public int ClassId { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime AuditTs { get; set; }
    }
}