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
    public class ClassShiftRepository : IClassShiftRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.ClassShift> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.ClassShift(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.ClassShift(), 1);
        }

        public Extems.Academic.Entities.ClassShift Get(int classShiftId)
        {
            return new Extems.Academic.Entities.ClassShift();
        }

        public IEnumerable<Extems.Academic.Entities.ClassShift> Get(int[] classShiftIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.ClassShift(), 1);
        }

        public Extems.Academic.Entities.ClassShift GetFirst()
        {
            return new Extems.Academic.Entities.ClassShift();
        }

        public Extems.Academic.Entities.ClassShift GetPrevious(int classShiftId)
        {
            return new Extems.Academic.Entities.ClassShift();
        }

        public Extems.Academic.Entities.ClassShift GetNext(int classShiftId)
        {
            return new Extems.Academic.Entities.ClassShift();
        }

        public Extems.Academic.Entities.ClassShift GetLast()
        {
            return new Extems.Academic.Entities.ClassShift();
        }

        public IEnumerable<Extems.Academic.Entities.ClassShift> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.ClassShift(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.ClassShift> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.ClassShift(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.ClassShift> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.ClassShift(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.ClassShift> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.ClassShift(), 1);
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

        public object AddOrEdit(dynamic classShift, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic classShift, int classShiftId)
        {
            if (classShiftId > 0)
            {
                return;
            }

            throw new ArgumentException("classShiftId is null.");
        }

        public object Add(dynamic classShift)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> classShifts)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int classShiftId)
        {
            if (classShiftId > 0)
            {
                return;
            }

            throw new ArgumentException("classShiftId is null.");
        }


    }
}