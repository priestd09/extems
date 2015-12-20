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
    public class ScholorshipTypeDetailRepository : IScholorshipTypeDetailRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetAll()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipTypeDetail(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipTypeDetail(), 1);
        }

        public Extems.Admission.Entities.ScholorshipTypeDetail Get(int scholorshipTypeDetailId)
        {
            return new Extems.Admission.Entities.ScholorshipTypeDetail();
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> Get(int[] scholorshipTypeDetailIds)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipTypeDetail(), 1);
        }

        public Extems.Admission.Entities.ScholorshipTypeDetail GetFirst()
        {
            return new Extems.Admission.Entities.ScholorshipTypeDetail();
        }

        public Extems.Admission.Entities.ScholorshipTypeDetail GetPrevious(int scholorshipTypeDetailId)
        {
            return new Extems.Admission.Entities.ScholorshipTypeDetail();
        }

        public Extems.Admission.Entities.ScholorshipTypeDetail GetNext(int scholorshipTypeDetailId)
        {
            return new Extems.Admission.Entities.ScholorshipTypeDetail();
        }

        public Extems.Admission.Entities.ScholorshipTypeDetail GetLast()
        {
            return new Extems.Admission.Entities.ScholorshipTypeDetail();
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipTypeDetail(), 1);
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipTypeDetail(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipTypeDetail(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.ScholorshipTypeDetail(), 1);
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

        public object AddOrEdit(dynamic scholorshipTypeDetail, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic scholorshipTypeDetail, int scholorshipTypeDetailId)
        {
            if (scholorshipTypeDetailId > 0)
            {
                return;
            }

            throw new ArgumentException("scholorshipTypeDetailId is null.");
        }

        public object Add(dynamic scholorshipTypeDetail)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> scholorshipTypeDetails)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int scholorshipTypeDetailId)
        {
            if (scholorshipTypeDetailId > 0)
            {
                return;
            }

            throw new ArgumentException("scholorshipTypeDetailId is null.");
        }


    }
}