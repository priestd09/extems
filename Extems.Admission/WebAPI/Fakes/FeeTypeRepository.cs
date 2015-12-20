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
    public class FeeTypeRepository : IFeeTypeRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.FeeType> GetAll()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.FeeType(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.FeeType(), 1);
        }

        public Extems.Admission.Entities.FeeType Get(int feeTypeId)
        {
            return new Extems.Admission.Entities.FeeType();
        }

        public IEnumerable<Extems.Admission.Entities.FeeType> Get(int[] feeTypeIds)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.FeeType(), 1);
        }

        public Extems.Admission.Entities.FeeType GetFirst()
        {
            return new Extems.Admission.Entities.FeeType();
        }

        public Extems.Admission.Entities.FeeType GetPrevious(int feeTypeId)
        {
            return new Extems.Admission.Entities.FeeType();
        }

        public Extems.Admission.Entities.FeeType GetNext(int feeTypeId)
        {
            return new Extems.Admission.Entities.FeeType();
        }

        public Extems.Admission.Entities.FeeType GetLast()
        {
            return new Extems.Admission.Entities.FeeType();
        }

        public IEnumerable<Extems.Admission.Entities.FeeType> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.FeeType(), 1);
        }

        public IEnumerable<Extems.Admission.Entities.FeeType> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.FeeType(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.FeeType> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.FeeType(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Admission.Entities.FeeType> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.FeeType(), 1);
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

        public object AddOrEdit(dynamic feeType, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic feeType, int feeTypeId)
        {
            if (feeTypeId > 0)
            {
                return;
            }

            throw new ArgumentException("feeTypeId is null.");
        }

        public object Add(dynamic feeType)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> feeTypes)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int feeTypeId)
        {
            if (feeTypeId > 0)
            {
                return;
            }

            throw new ArgumentException("feeTypeId is null.");
        }


    }
}