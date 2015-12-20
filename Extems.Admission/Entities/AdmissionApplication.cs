// ReSharper disable All
using System;
using Frapid.DataAccess;
using Frapid.NPoco;

namespace Extems.Admission.Entities
{
    [TableName("admission.admission_applications")]
    [PrimaryKey("admission_application_id", AutoIncrement = true)]
    public sealed class AdmissionApplication : IPoco
    {
        public long AdmissionApplicationId { get; set; }
        public int OfficeId { get; set; }
        public DateTime DateOfApplication { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string ZipCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneCell { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public int? BloodGroupId { get; set; }
        public string OtherDetails { get; set; }
        public int CourseId { get; set; }
        public int BatchId { get; set; }
        public string LastInstitutionName { get; set; }
        public int? PassedYear { get; set; }
        public string GradeObtained { get; set; }
        public decimal? PercentageObtained { get; set; }
        public bool ApplyForScholorship { get; set; }
        public DateTime? LastVerifiedOn { get; set; }
        public int? VerifiedByUserId { get; set; }
        public short VerificationStatusId { get; set; }
        public string VerificationReason { get; set; }
        public bool IsAddmitted { get; set; }
        public int? AuditUserId { get; set; }
        public DateTime? AuditTs { get; set; }
    }
}