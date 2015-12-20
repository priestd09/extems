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
    public class CourseRepository : ICourseRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Course> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Course(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Course(), 1);
        }

        public Extems.Academic.Entities.Course Get(int courseId)
        {
            return new Extems.Academic.Entities.Course();
        }

        public IEnumerable<Extems.Academic.Entities.Course> Get(int[] courseIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Course(), 1);
        }

        public Extems.Academic.Entities.Course GetFirst()
        {
            return new Extems.Academic.Entities.Course();
        }

        public Extems.Academic.Entities.Course GetPrevious(int courseId)
        {
            return new Extems.Academic.Entities.Course();
        }

        public Extems.Academic.Entities.Course GetNext(int courseId)
        {
            return new Extems.Academic.Entities.Course();
        }

        public Extems.Academic.Entities.Course GetLast()
        {
            return new Extems.Academic.Entities.Course();
        }

        public IEnumerable<Extems.Academic.Entities.Course> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Course(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.Course> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Course(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Course> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Course(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.Course> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Course(), 1);
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

        public object AddOrEdit(dynamic course, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic course, int courseId)
        {
            if (courseId > 0)
            {
                return;
            }

            throw new ArgumentException("courseId is null.");
        }

        public object Add(dynamic course)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> courses)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int courseId)
        {
            if (courseId > 0)
            {
                return;
            }

            throw new ArgumentException("courseId is null.");
        }


    }
}