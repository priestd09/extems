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
    public class AdmissionRepository : IAdmissionRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.Admission> GetAll()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Admission(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Admission(), 1);
        }

        public Extems.Admission.Entities.Admission Get(long admissionId)
        {
            return new Extems.Admission.Entities.Admission();
        }

        public IEnumerable<Extems.Admission.Entities.Admission> Get(long[] admissionIds)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Admission(), 1);
        }

        public Extems.Admission.Entities.Admission GetFirst()
        {
            return new Extems.Admission.Entities.Admission();
        }

        public Extems.Admission.Entities.Admission GetPrevious(long admissionId)
        {
            return new Extems.Admission.Entities.Admission();
        }

        public Extems.Admission.Entities.Admission GetNext(long admissionId)
        {
            return new Extems.Admission.Entities.Admission();
        }

        public Extems.Admission.Entities.Admission GetLast()
        {
            return new Extems.Admission.Entities.Admission();
        }

        public IEnumerable<Extems.Admission.Entities.Admission> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Admission(), 1);
        }

        public IEnumerable<Extems.Admission.Entities.Admission> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Admission(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.Admission> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Admission(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Admission.Entities.Admission> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Admission(), 1);
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

        public object AddOrEdit(dynamic admission, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic admission, long admissionId)
        {
            if (admissionId > 0)
            {
                return;
            }

            throw new ArgumentException("admissionId is null.");
        }

        public object Add(dynamic admission)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> admissions)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(long admissionId)
        {
            if (admissionId > 0)
            {
                return;
            }

            throw new ArgumentException("admissionId is null.");
        }


    }
}