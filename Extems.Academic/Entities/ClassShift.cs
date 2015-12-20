// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Academic.Entities
{
    [TableName("academic.class_shifts")]
    [PrimaryKey("class_shift_id", AutoIncrement = true)]
    public sealed class ClassShift : IPoco
    {
        public int ClassShiftId { get; set; }
        public string ClassShiftCode { get; set; }
        public string ClassShiftName { get; set; }
        public bool IsDeleted { get; set; }
    }
}