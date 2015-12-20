// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Admission.DataAccess
{
    public interface IScholorshipTypeRepository
    {
        /// <summary>
        /// Counts the number of ScholorshipType in IScholorshipTypeRepository.
        /// </summary>
        /// <returns>Returns the count of IScholorshipTypeRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of ScholorshipType. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of ScholorshipType.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipType> GetAll();

        /// <summary>
        /// Returns all instances of ScholorshipType to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of ScholorshipType.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the ScholorshipType against scholorshipTypeId. 
        /// </summary>
        /// <param name="scholorshipTypeId">The column "scholorship_type_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipType.</returns>
        Extems.Admission.Entities.ScholorshipType Get(int scholorshipTypeId);

        /// <summary>
        /// Gets the first record of ScholorshipType.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipType.</returns>
        Extems.Admission.Entities.ScholorshipType GetFirst();

        /// <summary>
        /// Gets the previous record of ScholorshipType sorted by scholorshipTypeId. 
        /// </summary>
        /// <param name="scholorshipTypeId">The column "scholorship_type_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipType.</returns>
        Extems.Admission.Entities.ScholorshipType GetPrevious(int scholorshipTypeId);

        /// <summary>
        /// Gets the next record of ScholorshipType sorted by scholorshipTypeId. 
        /// </summary>
        /// <param name="scholorshipTypeId">The column "scholorship_type_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipType.</returns>
        Extems.Admission.Entities.ScholorshipType GetNext(int scholorshipTypeId);

        /// <summary>
        /// Gets the last record of ScholorshipType.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipType.</returns>
        Extems.Admission.Entities.ScholorshipType GetLast();

        /// <summary>
        /// Returns multiple instances of the ScholorshipType against scholorshipTypeIds. 
        /// </summary>
        /// <param name="scholorshipTypeIds">Array of column "scholorship_type_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of ScholorshipType.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipType> Get(int[] scholorshipTypeIds);

        /// <summary>
        /// Custom fields are user defined form elements for IScholorshipTypeRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for ScholorshipType.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding ScholorshipType.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for ScholorshipType.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of ScholorshipType class to IScholorshipTypeRepository.
        /// </summary>
        /// <param name="scholorshipType">The instance of ScholorshipType class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic scholorshipType, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of ScholorshipType class to IScholorshipTypeRepository.
        /// </summary>
        /// <param name="scholorshipType">The instance of ScholorshipType class to insert.</param>
        object Add(dynamic scholorshipType);

        /// <summary>
        /// Inserts or updates multiple instances of ScholorshipType class to IScholorshipTypeRepository.;
        /// </summary>
        /// <param name="scholorshipTypes">List of ScholorshipType class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> scholorshipTypes);


        /// <summary>
        /// Updates IScholorshipTypeRepository with an instance of ScholorshipType class against the primary key value.
        /// </summary>
        /// <param name="scholorshipType">The instance of ScholorshipType class to update.</param>
        /// <param name="scholorshipTypeId">The value of the column "scholorship_type_id" which will be updated.</param>
        void Update(dynamic scholorshipType, int scholorshipTypeId);

        /// <summary>
        /// Deletes ScholorshipType from  IScholorshipTypeRepository against the primary key value.
        /// </summary>
        /// <param name="scholorshipTypeId">The value of the column "scholorship_type_id" which will be deleted.</param>
        void Delete(int scholorshipTypeId);

        /// <summary>
        /// Produces a paginated result of 10 ScholorshipType classes.
        /// </summary>
        /// <returns>Returns the first page of collection of ScholorshipType class.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipType> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 ScholorshipType classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of ScholorshipType class.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipType> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IScholorshipTypeRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of ScholorshipType class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IScholorshipTypeRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of ScholorshipType class.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipType> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IScholorshipTypeRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of ScholorshipType class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IScholorshipTypeRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of ScholorshipType class.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipType> GetFiltered(long pageNumber, string filterName);



    }
}