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
    public class ScholorshipRepository : IScholorshipRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.Scholorship> GetAll()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Scholorship(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Scholorship(), 1);
        }

        public Extems.Admission.Entities.Scholorship Get(long scholorshipId)
        {
            return new Extems.Admission.Entities.Scholorship();
        }

        public IEnumerable<Extems.Admission.Entities.Scholorship> Get(long[] scholorshipIds)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Scholorship(), 1);
        }

        public Extems.Admission.Entities.Scholorship GetFirst()
        {
            return new Extems.Admission.Entities.Scholorship();
        }

        public Extems.Admission.Entities.Scholorship GetPrevious(long scholorshipId)
        {
            return new Extems.Admission.Entities.Scholorship();
        }

        public Extems.Admission.Entities.Scholorship GetNext(long scholorshipId)
        {
            return new Extems.Admission.Entities.Scholorship();
        }

        public Extems.Admission.Entities.Scholorship GetLast()
        {
            return new Extems.Admission.Entities.Scholorship();
        }

        public IEnumerable<Extems.Admission.Entities.Scholorship> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Scholorship(), 1);
        }

        public IEnumerable<Extems.Admission.Entities.Scholorship> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Scholorship(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.Scholorship> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Scholorship(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Admission.Entities.Scholorship> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.Scholorship(), 1);
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

        public object AddOrEdit(dynamic scholorship, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic scholorship, long scholorshipId)
        {
            if (scholorshipId > 0)
            {
                return;
            }

            throw new ArgumentException("scholorshipId is null.");
        }

        public object Add(dynamic scholorship)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> scholorships)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(long scholorshipId)
        {
            if (scholorshipId > 0)
            {
                return;
            }

            throw new ArgumentException("scholorshipId is null.");
        }
        public void Verify(long scholorshipId, short verificationStatusId, string reason)
        {
            if (scholorshipId > 0)
            {
                return;
            }

            throw new ArgumentException("scholorshipId is null.");
        }

    }
}