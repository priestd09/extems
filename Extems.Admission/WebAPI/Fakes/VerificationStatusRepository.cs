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
    public class VerificationStatusRepository : IVerificationStatusRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetAll()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.VerificationStatus(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.VerificationStatus(), 1);
        }

        public Extems.Admission.Entities.VerificationStatus Get(short verificationStatusId)
        {
            return new Extems.Admission.Entities.VerificationStatus();
        }

        public IEnumerable<Extems.Admission.Entities.VerificationStatus> Get(short[] verificationStatusIds)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.VerificationStatus(), 1);
        }

        public Extems.Admission.Entities.VerificationStatus GetFirst()
        {
            return new Extems.Admission.Entities.VerificationStatus();
        }

        public Extems.Admission.Entities.VerificationStatus GetPrevious(short verificationStatusId)
        {
            return new Extems.Admission.Entities.VerificationStatus();
        }

        public Extems.Admission.Entities.VerificationStatus GetNext(short verificationStatusId)
        {
            return new Extems.Admission.Entities.VerificationStatus();
        }

        public Extems.Admission.Entities.VerificationStatus GetLast()
        {
            return new Extems.Admission.Entities.VerificationStatus();
        }

        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.VerificationStatus(), 1);
        }

        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.VerificationStatus(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.VerificationStatus(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Admission.Entities.VerificationStatus> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Admission.Entities.VerificationStatus(), 1);
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

        public object AddOrEdit(dynamic verificationStatus, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic verificationStatus, short verificationStatusId)
        {
            if (verificationStatusId > 0)
            {
                return;
            }

            throw new ArgumentException("verificationStatusId is null.");
        }

        public object Add(dynamic verificationStatus)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> verificationStatuses)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(short verificationStatusId)
        {
            if (verificationStatusId > 0)
            {
                return;
            }

            throw new ArgumentException("verificationStatusId is null.");
        }


    }
}