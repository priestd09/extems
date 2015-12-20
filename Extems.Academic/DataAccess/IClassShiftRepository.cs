// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface IClassShiftRepository
    {
        /// <summary>
        /// Counts the number of ClassShift in IClassShiftRepository.
        /// </summary>
        /// <returns>Returns the count of IClassShiftRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of ClassShift. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of ClassShift.</returns>
        IEnumerable<Extems.Academic.Entities.ClassShift> GetAll();

        /// <summary>
        /// Returns all instances of ClassShift to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of ClassShift.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the ClassShift against classShiftId. 
        /// </summary>
        /// <param name="classShiftId">The column "class_shift_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of ClassShift.</returns>
        Extems.Academic.Entities.ClassShift Get(int classShiftId);

        /// <summary>
        /// Gets the first record of ClassShift.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of ClassShift.</returns>
        Extems.Academic.Entities.ClassShift GetFirst();

        /// <summary>
        /// Gets the previous record of ClassShift sorted by classShiftId. 
        /// </summary>
        /// <param name="classShiftId">The column "class_shift_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of ClassShift.</returns>
        Extems.Academic.Entities.ClassShift GetPrevious(int classShiftId);

        /// <summary>
        /// Gets the next record of ClassShift sorted by classShiftId. 
        /// </summary>
        /// <param name="classShiftId">The column "class_shift_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of ClassShift.</returns>
        Extems.Academic.Entities.ClassShift GetNext(int classShiftId);

        /// <summary>
        /// Gets the last record of ClassShift.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of ClassShift.</returns>
        Extems.Academic.Entities.ClassShift GetLast();

        /// <summary>
        /// Returns multiple instances of the ClassShift against classShiftIds. 
        /// </summary>
        /// <param name="classShiftIds">Array of column "class_shift_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of ClassShift.</returns>
        IEnumerable<Extems.Academic.Entities.ClassShift> Get(int[] classShiftIds);

        /// <summary>
        /// Custom fields are user defined form elements for IClassShiftRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for ClassShift.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding ClassShift.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for ClassShift.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of ClassShift class to IClassShiftRepository.
        /// </summary>
        /// <param name="classShift">The instance of ClassShift class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic classShift, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of ClassShift class to IClassShiftRepository.
        /// </summary>
        /// <param name="classShift">The instance of ClassShift class to insert.</param>
        object Add(dynamic classShift);

        /// <summary>
        /// Inserts or updates multiple instances of ClassShift class to IClassShiftRepository.;
        /// </summary>
        /// <param name="classShifts">List of ClassShift class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> classShifts);


        /// <summary>
        /// Updates IClassShiftRepository with an instance of ClassShift class against the primary key value.
        /// </summary>
        /// <param name="classShift">The instance of ClassShift class to update.</param>
        /// <param name="classShiftId">The value of the column "class_shift_id" which will be updated.</param>
        void Update(dynamic classShift, int classShiftId);

        /// <summary>
        /// Deletes ClassShift from  IClassShiftRepository against the primary key value.
        /// </summary>
        /// <param name="classShiftId">The value of the column "class_shift_id" which will be deleted.</param>
        void Delete(int classShiftId);

        /// <summary>
        /// Produces a paginated result of 10 ClassShift classes.
        /// </summary>
        /// <returns>Returns the first page of collection of ClassShift class.</returns>
        IEnumerable<Extems.Academic.Entities.ClassShift> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 ClassShift classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of ClassShift class.</returns>
        IEnumerable<Extems.Academic.Entities.ClassShift> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IClassShiftRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of ClassShift class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IClassShiftRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of ClassShift class.</returns>
        IEnumerable<Extems.Academic.Entities.ClassShift> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IClassShiftRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of ClassShift class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IClassShiftRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of ClassShift class.</returns>
        IEnumerable<Extems.Academic.Entities.ClassShift> GetFiltered(long pageNumber, string filterName);



    }
}