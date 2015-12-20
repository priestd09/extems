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
    public class SectionRepository : ISectionRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Section> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Section(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Section(), 1);
        }

        public Extems.Academic.Entities.Section Get(int sectionId)
        {
            return new Extems.Academic.Entities.Section();
        }

        public IEnumerable<Extems.Academic.Entities.Section> Get(int[] sectionIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Section(), 1);
        }

        public Extems.Academic.Entities.Section GetFirst()
        {
            return new Extems.Academic.Entities.Section();
        }

        public Extems.Academic.Entities.Section GetPrevious(int sectionId)
        {
            return new Extems.Academic.Entities.Section();
        }

        public Extems.Academic.Entities.Section GetNext(int sectionId)
        {
            return new Extems.Academic.Entities.Section();
        }

        public Extems.Academic.Entities.Section GetLast()
        {
            return new Extems.Academic.Entities.Section();
        }

        public IEnumerable<Extems.Academic.Entities.Section> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Section(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.Section> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Section(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Section> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Section(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.Section> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Section(), 1);
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

        public object AddOrEdit(dynamic section, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic section, int sectionId)
        {
            if (sectionId > 0)
            {
                return;
            }

            throw new ArgumentException("sectionId is null.");
        }

        public object Add(dynamic section)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> sections)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int sectionId)
        {
            if (sectionId > 0)
            {
                return;
            }

            throw new ArgumentException("sectionId is null.");
        }


    }
}