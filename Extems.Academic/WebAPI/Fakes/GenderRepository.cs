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
    public class GenderRepository : IGenderRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Gender> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Gender(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Gender(), 1);
        }

        public Extems.Academic.Entities.Gender Get(int genderId)
        {
            return new Extems.Academic.Entities.Gender();
        }

        public IEnumerable<Extems.Academic.Entities.Gender> Get(int[] genderIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Gender(), 1);
        }

        public Extems.Academic.Entities.Gender GetFirst()
        {
            return new Extems.Academic.Entities.Gender();
        }

        public Extems.Academic.Entities.Gender GetPrevious(int genderId)
        {
            return new Extems.Academic.Entities.Gender();
        }

        public Extems.Academic.Entities.Gender GetNext(int genderId)
        {
            return new Extems.Academic.Entities.Gender();
        }

        public Extems.Academic.Entities.Gender GetLast()
        {
            return new Extems.Academic.Entities.Gender();
        }

        public IEnumerable<Extems.Academic.Entities.Gender> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Gender(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.Gender> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Gender(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Gender> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Gender(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.Gender> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Gender(), 1);
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

        public object AddOrEdit(dynamic gender, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic gender, int genderId)
        {
            if (genderId > 0)
            {
                return;
            }

            throw new ArgumentException("genderId is null.");
        }

        public object Add(dynamic gender)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> genders)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int genderId)
        {
            if (genderId > 0)
            {
                return;
            }

            throw new ArgumentException("genderId is null.");
        }


    }
}