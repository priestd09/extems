// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Admission.DataAccess
{
    public interface IFeeTypeRepository
    {
        /// <summary>
        /// Counts the number of FeeType in IFeeTypeRepository.
        /// </summary>
        /// <returns>Returns the count of IFeeTypeRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of FeeType. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of FeeType.</returns>
        IEnumerable<Extems.Admission.Entities.FeeType> GetAll();

        /// <summary>
        /// Returns all instances of FeeType to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of FeeType.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the FeeType against feeTypeId. 
        /// </summary>
        /// <param name="feeTypeId">The column "fee_type_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of FeeType.</returns>
        Extems.Admission.Entities.FeeType Get(int feeTypeId);

        /// <summary>
        /// Gets the first record of FeeType.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of FeeType.</returns>
        Extems.Admission.Entities.FeeType GetFirst();

        /// <summary>
        /// Gets the previous record of FeeType sorted by feeTypeId. 
        /// </summary>
        /// <param name="feeTypeId">The column "fee_type_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of FeeType.</returns>
        Extems.Admission.Entities.FeeType GetPrevious(int feeTypeId);

        /// <summary>
        /// Gets the next record of FeeType sorted by feeTypeId. 
        /// </summary>
        /// <param name="feeTypeId">The column "fee_type_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of FeeType.</returns>
        Extems.Admission.Entities.FeeType GetNext(int feeTypeId);

        /// <summary>
        /// Gets the last record of FeeType.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of FeeType.</returns>
        Extems.Admission.Entities.FeeType GetLast();

        /// <summary>
        /// Returns multiple instances of the FeeType against feeTypeIds. 
        /// </summary>
        /// <param name="feeTypeIds">Array of column "fee_type_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of FeeType.</returns>
        IEnumerable<Extems.Admission.Entities.FeeType> Get(int[] feeTypeIds);

        /// <summary>
        /// Custom fields are user defined form elements for IFeeTypeRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for FeeType.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding FeeType.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for FeeType.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of FeeType class to IFeeTypeRepository.
        /// </summary>
        /// <param name="feeType">The instance of FeeType class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic feeType, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of FeeType class to IFeeTypeRepository.
        /// </summary>
        /// <param name="feeType">The instance of FeeType class to insert.</param>
        object Add(dynamic feeType);

        /// <summary>
        /// Inserts or updates multiple instances of FeeType class to IFeeTypeRepository.;
        /// </summary>
        /// <param name="feeTypes">List of FeeType class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> feeTypes);


        /// <summary>
        /// Updates IFeeTypeRepository with an instance of FeeType class against the primary key value.
        /// </summary>
        /// <param name="feeType">The instance of FeeType class to update.</param>
        /// <param name="feeTypeId">The value of the column "fee_type_id" which will be updated.</param>
        void Update(dynamic feeType, int feeTypeId);

        /// <summary>
        /// Deletes FeeType from  IFeeTypeRepository against the primary key value.
        /// </summary>
        /// <param name="feeTypeId">The value of the column "fee_type_id" which will be deleted.</param>
        void Delete(int feeTypeId);

        /// <summary>
        /// Produces a paginated result of 10 FeeType classes.
        /// </summary>
        /// <returns>Returns the first page of collection of FeeType class.</returns>
        IEnumerable<Extems.Admission.Entities.FeeType> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 FeeType classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of FeeType class.</returns>
        IEnumerable<Extems.Admission.Entities.FeeType> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IFeeTypeRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of FeeType class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IFeeTypeRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of FeeType class.</returns>
        IEnumerable<Extems.Admission.Entities.FeeType> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IFeeTypeRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of FeeType class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IFeeTypeRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of FeeType class.</returns>
        IEnumerable<Extems.Admission.Entities.FeeType> GetFiltered(long pageNumber, string filterName);



    }
}