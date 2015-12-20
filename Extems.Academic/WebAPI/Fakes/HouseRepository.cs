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
    public class HouseRepository : IHouseRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.House> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.House(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.House(), 1);
        }

        public Extems.Academic.Entities.House Get(int houseId)
        {
            return new Extems.Academic.Entities.House();
        }

        public IEnumerable<Extems.Academic.Entities.House> Get(int[] houseIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.House(), 1);
        }

        public Extems.Academic.Entities.House GetFirst()
        {
            return new Extems.Academic.Entities.House();
        }

        public Extems.Academic.Entities.House GetPrevious(int houseId)
        {
            return new Extems.Academic.Entities.House();
        }

        public Extems.Academic.Entities.House GetNext(int houseId)
        {
            return new Extems.Academic.Entities.House();
        }

        public Extems.Academic.Entities.House GetLast()
        {
            return new Extems.Academic.Entities.House();
        }

        public IEnumerable<Extems.Academic.Entities.House> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.House(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.House> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.House(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.House> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.House(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.House> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.House(), 1);
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

        public object AddOrEdit(dynamic house, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic house, int houseId)
        {
            if (houseId > 0)
            {
                return;
            }

            throw new ArgumentException("houseId is null.");
        }

        public object Add(dynamic house)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> houses)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int houseId)
        {
            if (houseId > 0)
            {
                return;
            }

            throw new ArgumentException("houseId is null.");
        }


    }
}