// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface IAcademicLevelRepository
    {
        /// <summary>
        /// Counts the number of AcademicLevel in IAcademicLevelRepository.
        /// </summary>
        /// <returns>Returns the count of IAcademicLevelRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of AcademicLevel. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of AcademicLevel.</returns>
        IEnumerable<Extems.Academic.Entities.AcademicLevel> GetAll();

        /// <summary>
        /// Returns all instances of AcademicLevel to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of AcademicLevel.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the AcademicLevel against academicLevelId. 
        /// </summary>
        /// <param name="academicLevelId">The column "academic_level_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of AcademicLevel.</returns>
        Extems.Academic.Entities.AcademicLevel Get(int academicLevelId);

        /// <summary>
        /// Gets the first record of AcademicLevel.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of AcademicLevel.</returns>
        Extems.Academic.Entities.AcademicLevel GetFirst();

        /// <summary>
        /// Gets the previous record of AcademicLevel sorted by academicLevelId. 
        /// </summary>
        /// <param name="academicLevelId">The column "academic_level_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of AcademicLevel.</returns>
        Extems.Academic.Entities.AcademicLevel GetPrevious(int academicLevelId);

        /// <summary>
        /// Gets the next record of AcademicLevel sorted by academicLevelId. 
        /// </summary>
        /// <param name="academicLevelId">The column "academic_level_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of AcademicLevel.</returns>
        Extems.Academic.Entities.AcademicLevel GetNext(int academicLevelId);

        /// <summary>
        /// Gets the last record of AcademicLevel.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of AcademicLevel.</returns>
        Extems.Academic.Entities.AcademicLevel GetLast();

        /// <summary>
        /// Returns multiple instances of the AcademicLevel against academicLevelIds. 
        /// </summary>
        /// <param name="academicLevelIds">Array of column "academic_level_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of AcademicLevel.</returns>
        IEnumerable<Extems.Academic.Entities.AcademicLevel> Get(int[] academicLevelIds);

        /// <summary>
        /// Custom fields are user defined form elements for IAcademicLevelRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for AcademicLevel.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding AcademicLevel.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for AcademicLevel.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of AcademicLevel class to IAcademicLevelRepository.
        /// </summary>
        /// <param name="academicLevel">The instance of AcademicLevel class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic academicLevel, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of AcademicLevel class to IAcademicLevelRepository.
        /// </summary>
        /// <param name="academicLevel">The instance of AcademicLevel class to insert.</param>
        object Add(dynamic academicLevel);

        /// <summary>
        /// Inserts or updates multiple instances of AcademicLevel class to IAcademicLevelRepository.;
        /// </summary>
        /// <param name="academicLevels">List of AcademicLevel class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> academicLevels);


        /// <summary>
        /// Updates IAcademicLevelRepository with an instance of AcademicLevel class against the primary key value.
        /// </summary>
        /// <param name="academicLevel">The instance of AcademicLevel class to update.</param>
        /// <param name="academicLevelId">The value of the column "academic_level_id" which will be updated.</param>
        void Update(dynamic academicLevel, int academicLevelId);

        /// <summary>
        /// Deletes AcademicLevel from  IAcademicLevelRepository against the primary key value.
        /// </summary>
        /// <param name="academicLevelId">The value of the column "academic_level_id" which will be deleted.</param>
        void Delete(int academicLevelId);

        /// <summary>
        /// Produces a paginated result of 10 AcademicLevel classes.
        /// </summary>
        /// <returns>Returns the first page of collection of AcademicLevel class.</returns>
        IEnumerable<Extems.Academic.Entities.AcademicLevel> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 AcademicLevel classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of AcademicLevel class.</returns>
        IEnumerable<Extems.Academic.Entities.AcademicLevel> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IAcademicLevelRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of AcademicLevel class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IAcademicLevelRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of AcademicLevel class.</returns>
        IEnumerable<Extems.Academic.Entities.AcademicLevel> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IAcademicLevelRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of AcademicLevel class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IAcademicLevelRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of AcademicLevel class.</returns>
        IEnumerable<Extems.Academic.Entities.AcademicLevel> GetFiltered(long pageNumber, string filterName);



    }
}