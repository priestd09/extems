// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Extems.Admission.DataAccess;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;
using CustomField = Frapid.DataAccess.Models.CustomField;

namespace Extems.Admission.Api.Fakes
{
    public class AdmissionApplicationRepository : IAdmissionApplicationRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetAll()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.AdmissionApplication(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.AdmissionApplication(), 1);
        }

        public Extems.Admission.Entities.AdmissionApplication Get(long admissionApplicationId)
        {
            return new Extems.Admission.Entities.AdmissionApplication();
        }

        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> Get(long[] admissionApplicationIds)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.AdmissionApplication(), 1);
        }

        public Extems.Admission.Entities.AdmissionApplication GetFirst()
        {
            return new Extems.Admission.Entities.AdmissionApplication();
        }

        public Extems.Admission.Entities.AdmissionApplication GetPrevious(long admissionApplicationId)
        {
            return new Extems.Admission.Entities.AdmissionApplication();
        }

        public Extems.Admission.Entities.AdmissionApplication GetNext(long admissionApplicationId)
        {
            return new Extems.Admission.Entities.AdmissionApplication();
        }

        public Extems.Admission.Entities.AdmissionApplication GetLast()
        {
            return new Extems.Admission.Entities.AdmissionApplication();
        }

        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.AdmissionApplication(), 1);
        }

        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.AdmissionApplication(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.AdmissionApplication(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Admission.Entities.AdmissionApplication> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.AdmissionApplication(), 1);
        }

        public IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields()
        {
            return Enumerable.Repeat(new DisplayField(), 1);
        }

        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields()
        {
            return Enumerable.Repeat(new CustomField(), 1);
        }

        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId)
        {
            return Enumerable.Repeat(new CustomField(), 1);
        }

        public object AddOrEdit(dynamic admissionApplication, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic admissionApplication, long admissionApplicationId)
        {
            if (admissionApplicationId > 0)
            {
                return;
            }

            throw new ArgumentException("admissionApplicationId is null.");
        }

        public object Add(dynamic admissionApplication)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> admissionApplications)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(long admissionApplicationId)
        {
            if (admissionApplicationId > 0)
            {
                return;
            }

            throw new ArgumentException("admissionApplicationId is null.");
        }
        public void Verify(long admissionApplicationId, short verificationStatusId, string reason)
        {
            if (admissionApplicationId > 0)
            {
                return;
            }

            throw new ArgumentException("admissionApplicationId is null.");
        }

    }
}