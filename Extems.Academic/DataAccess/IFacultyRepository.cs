// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface IFacultyRepository
    {
        /// <summary>
        /// Counts the number of Faculty in IFacultyRepository.
        /// </summary>
        /// <returns>Returns the count of IFacultyRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of Faculty. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Faculty.</returns>
        IEnumerable<Extems.Academic.Entities.Faculty> GetAll();

        /// <summary>
        /// Returns all instances of Faculty to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Faculty.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the Faculty against facultyId. 
        /// </summary>
        /// <param name="facultyId">The column "faculty_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of Faculty.</returns>
        Extems.Academic.Entities.Faculty Get(int facultyId);

        /// <summary>
        /// Gets the first record of Faculty.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Faculty.</returns>
        Extems.Academic.Entities.Faculty GetFirst();

        /// <summary>
        /// Gets the previous record of Faculty sorted by facultyId. 
        /// </summary>
        /// <param name="facultyId">The column "faculty_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Faculty.</returns>
        Extems.Academic.Entities.Faculty GetPrevious(int facultyId);

        /// <summary>
        /// Gets the next record of Faculty sorted by facultyId. 
        /// </summary>
        /// <param name="facultyId">The column "faculty_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Faculty.</returns>
        Extems.Academic.Entities.Faculty GetNext(int facultyId);

        /// <summary>
        /// Gets the last record of Faculty.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Faculty.</returns>
        Extems.Academic.Entities.Faculty GetLast();

        /// <summary>
        /// Returns multiple instances of the Faculty against facultyIds. 
        /// </summary>
        /// <param name="facultyIds">Array of column "faculty_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of Faculty.</returns>
        IEnumerable<Extems.Academic.Entities.Faculty> Get(int[] facultyIds);

        /// <summary>
        /// Custom fields are user defined form elements for IFacultyRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for Faculty.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding Faculty.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for Faculty.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of Faculty class to IFacultyRepository.
        /// </summary>
        /// <param name="faculty">The instance of Faculty class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic faculty, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of Faculty class to IFacultyRepository.
        /// </summary>
        /// <param name="faculty">The instance of Faculty class to insert.</param>
        object Add(dynamic faculty);

        /// <summary>
        /// Inserts or updates multiple instances of Faculty class to IFacultyRepository.;
        /// </summary>
        /// <param name="faculties">List of Faculty class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> faculties);


        /// <summary>
        /// Updates IFacultyRepository with an instance of Faculty class against the primary key value.
        /// </summary>
        /// <param name="faculty">The instance of Faculty class to update.</param>
        /// <param name="facultyId">The value of the column "faculty_id" which will be updated.</param>
        void Update(dynamic faculty, int facultyId);

        /// <summary>
        /// Deletes Faculty from  IFacultyRepository against the primary key value.
        /// </summary>
        /// <param name="facultyId">The value of the column "faculty_id" which will be deleted.</param>
        void Delete(int facultyId);

        /// <summary>
        /// Produces a paginated result of 10 Faculty classes.
        /// </summary>
        /// <returns>Returns the first page of collection of Faculty class.</returns>
        IEnumerable<Extems.Academic.Entities.Faculty> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 Faculty classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of Faculty class.</returns>
        IEnumerable<Extems.Academic.Entities.Faculty> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IFacultyRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of Faculty class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IFacultyRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of Faculty class.</returns>
        IEnumerable<Extems.Academic.Entities.Faculty> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IFacultyRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of Faculty class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IFacultyRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of Faculty class.</returns>
        IEnumerable<Extems.Academic.Entities.Faculty> GetFiltered(long pageNumber, string filterName);



    }
}