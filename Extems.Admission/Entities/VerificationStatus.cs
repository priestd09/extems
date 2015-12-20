// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Admission.Entities
{
    [TableName("admission.verification_statuses")]
    [PrimaryKey("verification_status_id", AutoIncrement = false)]
    public sealed class VerificationStatus : IPoco
    {
        public short VerificationStatusId { get; set; }
    }
}