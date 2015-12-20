// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.genders")]
    [PrimaryKey("gender_id", AutoIncrement = true)]
    public sealed class Gender : IPoco
    {
        public int GenderId { get; set; }
        public string GenderCode { get; set; }
        public string GenderName { get; set; }
        public bool IsDeleted { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}