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
    public class BatchRepository : IBatchRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Batch> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Batch(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Batch(), 1);
        }

        public Extems.Academic.Entities.Batch Get(int batchId)
        {
            return new Extems.Academic.Entities.Batch();
        }

        public IEnumerable<Extems.Academic.Entities.Batch> Get(int[] batchIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Batch(), 1);
        }

        public Extems.Academic.Entities.Batch GetFirst()
        {
            return new Extems.Academic.Entities.Batch();
        }

        public Extems.Academic.Entities.Batch GetPrevious(int batchId)
        {
            return new Extems.Academic.Entities.Batch();
        }

        public Extems.Academic.Entities.Batch GetNext(int batchId)
        {
            return new Extems.Academic.Entities.Batch();
        }

        public Extems.Academic.Entities.Batch GetLast()
        {
            return new Extems.Academic.Entities.Batch();
        }

        public IEnumerable<Extems.Academic.Entities.Batch> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Batch(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.Batch> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Batch(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.Batch> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Batch(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.Batch> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.Batch(), 1);
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

        public object AddOrEdit(dynamic batch, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic batch, int batchId)
        {
            if (batchId > 0)
            {
                return;
            }

            throw new ArgumentException("batchId is null.");
        }

        public object Add(dynamic batch)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> batches)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int batchId)
        {
            if (batchId > 0)
            {
                return;
            }

            throw new ArgumentException("batchId is null.");
        }


    }
}