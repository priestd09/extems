// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface IBloodGroupRepository
    {
        /// <summary>
        /// Counts the number of BloodGroup in IBloodGroupRepository.
        /// </summary>
        /// <returns>Returns the count of IBloodGroupRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of BloodGroup. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of BloodGroup.</returns>
        IEnumerable<Extems.Academic.Entities.BloodGroup> GetAll();

        /// <summary>
        /// Returns all instances of BloodGroup to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of BloodGroup.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the BloodGroup against bloodGroupId. 
        /// </summary>
        /// <param name="bloodGroupId">The column "blood_group_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of BloodGroup.</returns>
        Extems.Academic.Entities.BloodGroup Get(int bloodGroupId);

        /// <summary>
        /// Gets the first record of BloodGroup.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of BloodGroup.</returns>
        Extems.Academic.Entities.BloodGroup GetFirst();

        /// <summary>
        /// Gets the previous record of BloodGroup sorted by bloodGroupId. 
        /// </summary>
        /// <param name="bloodGroupId">The column "blood_group_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of BloodGroup.</returns>
        Extems.Academic.Entities.BloodGroup GetPrevious(int bloodGroupId);

        /// <summary>
        /// Gets the next record of BloodGroup sorted by bloodGroupId. 
        /// </summary>
        /// <param name="bloodGroupId">The column "blood_group_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of BloodGroup.</returns>
        Extems.Academic.Entities.BloodGroup GetNext(int bloodGroupId);

        /// <summary>
        /// Gets the last record of BloodGroup.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of BloodGroup.</returns>
        Extems.Academic.Entities.BloodGroup GetLast();

        /// <summary>
        /// Returns multiple instances of the BloodGroup against bloodGroupIds. 
        /// </summary>
        /// <param name="bloodGroupIds">Array of column "blood_group_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of BloodGroup.</returns>
        IEnumerable<Extems.Academic.Entities.BloodGroup> Get(int[] bloodGroupIds);

        /// <summary>
        /// Custom fields are user defined form elements for IBloodGroupRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for BloodGroup.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding BloodGroup.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for BloodGroup.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of BloodGroup class to IBloodGroupRepository.
        /// </summary>
        /// <param name="bloodGroup">The instance of BloodGroup class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic bloodGroup, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of BloodGroup class to IBloodGroupRepository.
        /// </summary>
        /// <param name="bloodGroup">The instance of BloodGroup class to insert.</param>
        object Add(dynamic bloodGroup);

        /// <summary>
        /// Inserts or updates multiple instances of BloodGroup class to IBloodGroupRepository.;
        /// </summary>
        /// <param name="bloodGroups">List of BloodGroup class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> bloodGroups);


        /// <summary>
        /// Updates IBloodGroupRepository with an instance of BloodGroup class against the primary key value.
        /// </summary>
        /// <param name="bloodGroup">The instance of BloodGroup class to update.</param>
        /// <param name="bloodGroupId">The value of the column "blood_group_id" which will be updated.</param>
        void Update(dynamic bloodGroup, int bloodGroupId);

        /// <summary>
        /// Deletes BloodGroup from  IBloodGroupRepository against the primary key value.
        /// </summary>
        /// <param name="bloodGroupId">The value of the column "blood_group_id" which will be deleted.</param>
        void Delete(int bloodGroupId);

        /// <summary>
        /// Produces a paginated result of 10 BloodGroup classes.
        /// </summary>
        /// <returns>Returns the first page of collection of BloodGroup class.</returns>
        IEnumerable<Extems.Academic.Entities.BloodGroup> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 BloodGroup classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of BloodGroup class.</returns>
        IEnumerable<Extems.Academic.Entities.BloodGroup> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IBloodGroupRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of BloodGroup class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IBloodGroupRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of BloodGroup class.</returns>
        IEnumerable<Extems.Academic.Entities.BloodGroup> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IBloodGroupRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of BloodGroup class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IBloodGroupRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of BloodGroup class.</returns>
        IEnumerable<Extems.Academic.Entities.BloodGroup> GetFiltered(long pageNumber, string filterName);



    }
}