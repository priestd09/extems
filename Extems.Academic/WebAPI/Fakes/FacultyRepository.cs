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
    public class FacultyRepository : IFacultyRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Faculty> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Faculty(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Faculty(), 1);
        }

        public Extems.Academic.Entities.Faculty Get(int facultyId)
        {
            return new Extems.Academic.Entities.Faculty();
        }

        public IEnumerable<Extems.Academic.Entities.Faculty> Get(int[] facultyIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Faculty(), 1);
        }

        public Extems.Academic.Entities.Faculty GetFirst()
        {
            return new Extems.Academic.Entities.Faculty();
        }

        public Extems.Academic.Entities.Faculty GetPrevious(int facultyId)
        {
            return new Extems.Academic.Entities.Faculty();
        }

        public Extems.Academic.Entities.Faculty GetNext(int facultyId)
        {
            return new Extems.Academic.Entities.Faculty();
        }

        public Extems.Academic.Entities.Faculty GetLast()
        {
            return new Extems.Academic.Entities.Faculty();
        }

        public IEnumerable<Extems.Academic.Entities.Faculty> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Faculty(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.Faculty> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Faculty(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Faculty> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Faculty(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.Faculty> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Faculty(), 1);
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

        public object AddOrEdit(dynamic faculty, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic faculty, int facultyId)
        {
            if (facultyId > 0)
            {
                return;
            }

            throw new ArgumentException("facultyId is null.");
        }

        public object Add(dynamic faculty)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> faculties)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int facultyId)
        {
            if (facultyId > 0)
            {
                return;
            }

            throw new ArgumentException("facultyId is null.");
        }


    }
}