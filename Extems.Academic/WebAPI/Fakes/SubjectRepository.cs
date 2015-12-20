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
    public class SubjectRepository : ISubjectRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Subject> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Subject(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Subject(), 1);
        }

        public Extems.Academic.Entities.Subject Get(int subjectId)
        {
            return new Extems.Academic.Entities.Subject();
        }

        public IEnumerable<Extems.Academic.Entities.Subject> Get(int[] subjectIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Subject(), 1);
        }

        public Extems.Academic.Entities.Subject GetFirst()
        {
            return new Extems.Academic.Entities.Subject();
        }

        public Extems.Academic.Entities.Subject GetPrevious(int subjectId)
        {
            return new Extems.Academic.Entities.Subject();
        }

        public Extems.Academic.Entities.Subject GetNext(int subjectId)
        {
            return new Extems.Academic.Entities.Subject();
        }

        public Extems.Academic.Entities.Subject GetLast()
        {
            return new Extems.Academic.Entities.Subject();
        }

        public IEnumerable<Extems.Academic.Entities.Subject> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Subject(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.Subject> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Subject(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Subject> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Subject(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.Subject> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Subject(), 1);
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

        public object AddOrEdit(dynamic subject, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic subject, int subjectId)
        {
            if (subjectId > 0)
            {
                return;
            }

            throw new ArgumentException("subjectId is null.");
        }

        public object Add(dynamic subject)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> subjects)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int subjectId)
        {
            if (subjectId > 0)
            {
                return;
            }

            throw new ArgumentException("subjectId is null.");
        }


    }
}