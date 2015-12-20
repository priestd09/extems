// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Admission.DataAccess
{
    public interface IScholorshipTypeDetailRepository
    {
        /// <summary>
        /// Counts the number of ScholorshipTypeDetail in IScholorshipTypeDetailRepository.
        /// </summary>
        /// <returns>Returns the count of IScholorshipTypeDetailRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of ScholorshipTypeDetail. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of ScholorshipTypeDetail.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetAll();

        /// <summary>
        /// Returns all instances of ScholorshipTypeDetail to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of ScholorshipTypeDetail.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the ScholorshipTypeDetail against scholorshipTypeDetailId. 
        /// </summary>
        /// <param name="scholorshipTypeDetailId">The column "scholorship_type_detail_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipTypeDetail.</returns>
        Extems.Admission.Entities.ScholorshipTypeDetail Get(int scholorshipTypeDetailId);

        /// <summary>
        /// Gets the first record of ScholorshipTypeDetail.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipTypeDetail.</returns>
        Extems.Admission.Entities.ScholorshipTypeDetail GetFirst();

        /// <summary>
        /// Gets the previous record of ScholorshipTypeDetail sorted by scholorshipTypeDetailId. 
        /// </summary>
        /// <param name="scholorshipTypeDetailId">The column "scholorship_type_detail_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipTypeDetail.</returns>
        Extems.Admission.Entities.ScholorshipTypeDetail GetPrevious(int scholorshipTypeDetailId);

        /// <summary>
        /// Gets the next record of ScholorshipTypeDetail sorted by scholorshipTypeDetailId. 
        /// </summary>
        /// <param name="scholorshipTypeDetailId">The column "scholorship_type_detail_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipTypeDetail.</returns>
        Extems.Admission.Entities.ScholorshipTypeDetail GetNext(int scholorshipTypeDetailId);

        /// <summary>
        /// Gets the last record of ScholorshipTypeDetail.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of ScholorshipTypeDetail.</returns>
        Extems.Admission.Entities.ScholorshipTypeDetail GetLast();

        /// <summary>
        /// Returns multiple instances of the ScholorshipTypeDetail against scholorshipTypeDetailIds. 
        /// </summary>
        /// <param name="scholorshipTypeDetailIds">Array of column "scholorship_type_detail_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of ScholorshipTypeDetail.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> Get(int[] scholorshipTypeDetailIds);

        /// <summary>
        /// Custom fields are user defined form elements for IScholorshipTypeDetailRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for ScholorshipTypeDetail.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding ScholorshipTypeDetail.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for ScholorshipTypeDetail.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of ScholorshipTypeDetail class to IScholorshipTypeDetailRepository.
        /// </summary>
        /// <param name="scholorshipTypeDetail">The instance of ScholorshipTypeDetail class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic scholorshipTypeDetail, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of ScholorshipTypeDetail class to IScholorshipTypeDetailRepository.
        /// </summary>
        /// <param name="scholorshipTypeDetail">The instance of ScholorshipTypeDetail class to insert.</param>
        object Add(dynamic scholorshipTypeDetail);

        /// <summary>
        /// Inserts or updates multiple instances of ScholorshipTypeDetail class to IScholorshipTypeDetailRepository.;
        /// </summary>
        /// <param name="scholorshipTypeDetails">List of ScholorshipTypeDetail class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> scholorshipTypeDetails);


        /// <summary>
        /// Updates IScholorshipTypeDetailRepository with an instance of ScholorshipTypeDetail class against the primary key value.
        /// </summary>
        /// <param name="scholorshipTypeDetail">The instance of ScholorshipTypeDetail class to update.</param>
        /// <param name="scholorshipTypeDetailId">The value of the column "scholorship_type_detail_id" which will be updated.</param>
        void Update(dynamic scholorshipTypeDetail, int scholorshipTypeDetailId);

        /// <summary>
        /// Deletes ScholorshipTypeDetail from  IScholorshipTypeDetailRepository against the primary key value.
        /// </summary>
        /// <param name="scholorshipTypeDetailId">The value of the column "scholorship_type_detail_id" which will be deleted.</param>
        void Delete(int scholorshipTypeDetailId);

        /// <summary>
        /// Produces a paginated result of 10 ScholorshipTypeDetail classes.
        /// </summary>
        /// <returns>Returns the first page of collection of ScholorshipTypeDetail class.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 ScholorshipTypeDetail classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of ScholorshipTypeDetail class.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IScholorshipTypeDetailRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of ScholorshipTypeDetail class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IScholorshipTypeDetailRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of ScholorshipTypeDetail class.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IScholorshipTypeDetailRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of ScholorshipTypeDetail class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IScholorshipTypeDetailRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of ScholorshipTypeDetail class.</returns>
        IEnumerable<Extems.Admission.Entities.ScholorshipTypeDetail> GetFiltered(long pageNumber, string filterName);



    }
}