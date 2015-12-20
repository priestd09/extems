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
    public class ScholorshipTypeRepository : IScholorshipTypeRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipType> GetAll()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipType(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipType(), 1);
        }

        public Extems.Admission.Entities.ScholorshipType Get(int scholorshipTypeId)
        {
            return new Extems.Admission.Entities.ScholorshipType();
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipType> Get(int[] scholorshipTypeIds)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipType(), 1);
        }

        public Extems.Admission.Entities.ScholorshipType GetFirst()
        {
            return new Extems.Admission.Entities.ScholorshipType();
        }

        public Extems.Admission.Entities.ScholorshipType GetPrevious(int scholorshipTypeId)
        {
            return new Extems.Admission.Entities.ScholorshipType();
        }

        public Extems.Admission.Entities.ScholorshipType GetNext(int scholorshipTypeId)
        {
            return new Extems.Admission.Entities.ScholorshipType();
        }

        public Extems.Admission.Entities.ScholorshipType GetLast()
        {
            return new Extems.Admission.Entities.ScholorshipType();
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipType> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipType(), 1);
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipType> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipType(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipType> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipType(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipType> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipType(), 1);
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

        public object AddOrEdit(dynamic scholorshipType, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic scholorshipType, int scholorshipTypeId)
        {
            if (scholorshipTypeId > 0)
            {
                return;
            }

            throw new ArgumentException("scholorshipTypeId is null.");
        }

        public object Add(dynamic scholorshipType)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> scholorshipTypes)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int scholorshipTypeId)
        {
            if (scholorshipTypeId > 0)
            {
                return;
            }

            throw new ArgumentException("scholorshipTypeId is null.");
        }


    }
}