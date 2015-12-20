// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface ISubjectRepository
    {
        /// <summary>
        /// Counts the number of Subject in ISubjectRepository.
        /// </summary>
        /// <returns>Returns the count of ISubjectRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of Subject. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Subject.</returns>
        IEnumerable<Extems.Academic.Entities.Subject> GetAll();

        /// <summary>
        /// Returns all instances of Subject to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Subject.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the Subject against subjectId. 
        /// </summary>
        /// <param name="subjectId">The column "subject_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of Subject.</returns>
        Extems.Academic.Entities.Subject Get(int subjectId);

        /// <summary>
        /// Gets the first record of Subject.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Subject.</returns>
        Extems.Academic.Entities.Subject GetFirst();

        /// <summary>
        /// Gets the previous record of Subject sorted by subjectId. 
        /// </summary>
        /// <param name="subjectId">The column "subject_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Subject.</returns>
        Extems.Academic.Entities.Subject GetPrevious(int subjectId);

        /// <summary>
        /// Gets the next record of Subject sorted by subjectId. 
        /// </summary>
        /// <param name="subjectId">The column "subject_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Subject.</returns>
        Extems.Academic.Entities.Subject GetNext(int subjectId);

        /// <summary>
        /// Gets the last record of Subject.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Subject.</returns>
        Extems.Academic.Entities.Subject GetLast();

        /// <summary>
        /// Returns multiple instances of the Subject against subjectIds. 
        /// </summary>
        /// <param name="subjectIds">Array of column "subject_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of Subject.</returns>
        IEnumerable<Extems.Academic.Entities.Subject> Get(int[] subjectIds);

        /// <summary>
        /// Custom fields are user defined form elements for ISubjectRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for Subject.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding Subject.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for Subject.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of Subject class to ISubjectRepository.
        /// </summary>
        /// <param name="subject">The instance of Subject class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic subject, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of Subject class to ISubjectRepository.
        /// </summary>
        /// <param name="subject">The instance of Subject class to insert.</param>
        object Add(dynamic subject);

        /// <summary>
        /// Inserts or updates multiple instances of Subject class to ISubjectRepository.;
        /// </summary>
        /// <param name="subjects">List of Subject class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> subjects);


        /// <summary>
        /// Updates ISubjectRepository with an instance of Subject class against the primary key value.
        /// </summary>
        /// <param name="subject">The instance of Subject class to update.</param>
        /// <param name="subjectId">The value of the column "subject_id" which will be updated.</param>
        void Update(dynamic subject, int subjectId);

        /// <summary>
        /// Deletes Subject from  ISubjectRepository against the primary key value.
        /// </summary>
        /// <param name="subjectId">The value of the column "subject_id" which will be deleted.</param>
        void Delete(int subjectId);

        /// <summary>
        /// Produces a paginated result of 10 Subject classes.
        /// </summary>
        /// <returns>Returns the first page of collection of Subject class.</returns>
        IEnumerable<Extems.Academic.Entities.Subject> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 Subject classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of Subject class.</returns>
        IEnumerable<Extems.Academic.Entities.Subject> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on ISubjectRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of Subject class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against ISubjectRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of Subject class.</returns>
        IEnumerable<Extems.Academic.Entities.Subject> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on ISubjectRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of Subject class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of ISubjectRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of Subject class.</returns>
        IEnumerable<Extems.Academic.Entities.Subject> GetFiltered(long pageNumber, string filterName);



    }
}