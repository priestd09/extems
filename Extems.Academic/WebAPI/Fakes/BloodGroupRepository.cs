// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Extems.Academic.DataAccess;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;
using CustomField = Frapid.DataAccess.Models.CustomField;

namespace Extems.Academic.Api.Fakes
{
    public class BloodGroupRepository : IBloodGroupRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.BloodGroup> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.BloodGroup(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.BloodGroup(), 1);
        }

        public Extems.Academic.Entities.BloodGroup Get(int bloodGroupId)
        {
            return new Extems.Academic.Entities.BloodGroup();
        }

        public IEnumerable<Extems.Academic.Entities.BloodGroup> Get(int[] bloodGroupIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.BloodGroup(), 1);
        }

        public Extems.Academic.Entities.BloodGroup GetFirst()
        {
            return new Extems.Academic.Entities.BloodGroup();
        }

        public Extems.Academic.Entities.BloodGroup GetPrevious(int bloodGroupId)
        {
            return new Extems.Academic.Entities.BloodGroup();
        }

        public Extems.Academic.Entities.BloodGroup GetNext(int bloodGroupId)
        {
            return new Extems.Academic.Entities.BloodGroup();
        }

        public Extems.Academic.Entities.BloodGroup GetLast()
        {
            return new Extems.Academic.Entities.BloodGroup();
        }

        public IEnumerable<Extems.Academic.Entities.BloodGroup> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.BloodGroup(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.BloodGroup> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.BloodGroup(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.BloodGroup> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.BloodGroup(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.BloodGroup> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.BloodGroup(), 1);
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

        public object AddOrEdit(dynamic bloodGroup, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic bloodGroup, int bloodGroupId)
        {
            if (bloodGroupId > 0)
            {
                return;
            }

            throw new ArgumentException("bloodGroupId is null.");
        }

        public object Add(dynamic bloodGroup)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> bloodGroups)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int bloodGroupId)
        {
            if (bloodGroupId > 0)
            {
                return;
            }

            throw new ArgumentException("bloodGroupId is null.");
        }


    }
}