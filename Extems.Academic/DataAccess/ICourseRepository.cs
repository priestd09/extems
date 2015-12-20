// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface ICourseRepository
    {
        /// <summary>
        /// Counts the number of Course in ICourseRepository.
        /// </summary>
        /// <returns>Returns the count of ICourseRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of Course. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Course.</returns>
        IEnumerable<Extems.Academic.Entities.Course> GetAll();

        /// <summary>
        /// Returns all instances of Course to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Course.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the Course against courseId. 
        /// </summary>
        /// <param name="courseId">The column "course_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of Course.</returns>
        Extems.Academic.Entities.Course Get(int courseId);

        /// <summary>
        /// Gets the first record of Course.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Course.</returns>
        Extems.Academic.Entities.Course GetFirst();

        /// <summary>
        /// Gets the previous record of Course sorted by courseId. 
        /// </summary>
        /// <param name="courseId">The column "course_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Course.</returns>
        Extems.Academic.Entities.Course GetPrevious(int courseId);

        /// <summary>
        /// Gets the next record of Course sorted by courseId. 
        /// </summary>
        /// <param name="courseId">The column "course_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Course.</returns>
        Extems.Academic.Entities.Course GetNext(int courseId);

        /// <summary>
        /// Gets the last record of Course.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Course.</returns>
        Extems.Academic.Entities.Course GetLast();

        /// <summary>
        /// Returns multiple instances of the Course against courseIds. 
        /// </summary>
        /// <param name="courseIds">Array of column "course_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of Course.</returns>
        IEnumerable<Extems.Academic.Entities.Course> Get(int[] courseIds);

        /// <summary>
        /// Custom fields are user defined form elements for ICourseRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for Course.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding Course.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for Course.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of Course class to ICourseRepository.
        /// </summary>
        /// <param name="course">The instance of Course class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic course, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of Course class to ICourseRepository.
        /// </summary>
        /// <param name="course">The instance of Course class to insert.</param>
        object Add(dynamic course);

        /// <summary>
        /// Inserts or updates multiple instances of Course class to ICourseRepository.;
        /// </summary>
        /// <param name="courses">List of Course class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> courses);


        /// <summary>
        /// Updates ICourseRepository with an instance of Course class against the primary key value.
        /// </summary>
        /// <param name="course">The instance of Course class to update.</param>
        /// <param name="courseId">The value of the column "course_id" which will be updated.</param>
        void Update(dynamic course, int courseId);

        /// <summary>
        /// Deletes Course from  ICourseRepository against the primary key value.
        /// </summary>
        /// <param name="courseId">The value of the column "course_id" which will be deleted.</param>
        void Delete(int courseId);

        /// <summary>
        /// Produces a paginated result of 10 Course classes.
        /// </summary>
        /// <returns>Returns the first page of collection of Course class.</returns>
        IEnumerable<Extems.Academic.Entities.Course> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 Course classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of Course class.</returns>
        IEnumerable<Extems.Academic.Entities.Course> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on ICourseRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of Course class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against ICourseRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of Course class.</returns>
        IEnumerable<Extems.Academic.Entities.Course> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on ICourseRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of Course class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of ICourseRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of Course class.</returns>
        IEnumerable<Extems.Academic.Entities.Course> GetFiltered(long pageNumber, string filterName);



    }
}