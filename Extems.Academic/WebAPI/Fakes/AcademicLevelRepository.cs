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
    public class AcademicLevelRepository : IAcademicLevelRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetAll()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.AcademicLevel(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.AcademicLevel(), 1);
        }

        public Extems.Academic.Entities.AcademicLevel Get(int academicLevelId)
        {
            return new Extems.Academic.Entities.AcademicLevel();
        }

        public IEnumerable<Extems.Academic.Entities.AcademicLevel> Get(int[] academicLevelIds)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.AcademicLevel(), 1);
        }

        public Extems.Academic.Entities.AcademicLevel GetFirst()
        {
            return new Extems.Academic.Entities.AcademicLevel();
        }

        public Extems.Academic.Entities.AcademicLevel GetPrevious(int academicLevelId)
        {
            return new Extems.Academic.Entities.AcademicLevel();
        }

        public Extems.Academic.Entities.AcademicLevel GetNext(int academicLevelId)
        {
            return new Extems.Academic.Entities.AcademicLevel();
        }

        public Extems.Academic.Entities.AcademicLevel GetLast()
        {
            return new Extems.Academic.Entities.AcademicLevel();
        }

        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetPaginatedResult()
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.AcademicLevel(), 1);
        }

        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.AcademicLevel(), 1);
        }

        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.AcademicLevel(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new Frapid.DataAccess.Models.Filter(), 1).ToList();
        }

        public IEnumerable<Extems.Academic.Entities.AcademicLevel> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new Extems.Academic.Entities.AcademicLevel(), 1);
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

        public object AddOrEdit(dynamic academicLevel, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic academicLevel, int academicLevelId)
        {
            if (academicLevelId > 0)
            {
                return;
            }

            throw new ArgumentException("academicLevelId is null.");
        }

        public object Add(dynamic academicLevel)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> academicLevels)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int academicLevelId)
        {
            if (academicLevelId > 0)
            {
                return;
            }

            throw new ArgumentException("academicLevelId is null.");
        }


    }
}