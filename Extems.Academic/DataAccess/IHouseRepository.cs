// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface IHouseRepository
    {
        /// <summary>
        /// Counts the number of House in IHouseRepository.
        /// </summary>
        /// <returns>Returns the count of IHouseRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of House. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of House.</returns>
        IEnumerable<Extems.Academic.Entities.House> GetAll();

        /// <summary>
        /// Returns all instances of House to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of House.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the House against houseId. 
        /// </summary>
        /// <param name="houseId">The column "house_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of House.</returns>
        Extems.Academic.Entities.House Get(int houseId);

        /// <summary>
        /// Gets the first record of House.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of House.</returns>
        Extems.Academic.Entities.House GetFirst();

        /// <summary>
        /// Gets the previous record of House sorted by houseId. 
        /// </summary>
        /// <param name="houseId">The column "house_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of House.</returns>
        Extems.Academic.Entities.House GetPrevious(int houseId);

        /// <summary>
        /// Gets the next record of House sorted by houseId. 
        /// </summary>
        /// <param name="houseId">The column "house_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of House.</returns>
        Extems.Academic.Entities.House GetNext(int houseId);

        /// <summary>
        /// Gets the last record of House.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of House.</returns>
        Extems.Academic.Entities.House GetLast();

        /// <summary>
        /// Returns multiple instances of the House against houseIds. 
        /// </summary>
        /// <param name="houseIds">Array of column "house_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of House.</returns>
        IEnumerable<Extems.Academic.Entities.House> Get(int[] houseIds);

        /// <summary>
        /// Custom fields are user defined form elements for IHouseRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for House.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding House.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for House.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of House class to IHouseRepository.
        /// </summary>
        /// <param name="house">The instance of House class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic house, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of House class to IHouseRepository.
        /// </summary>
        /// <param name="house">The instance of House class to insert.</param>
        object Add(dynamic house);

        /// <summary>
        /// Inserts or updates multiple instances of House class to IHouseRepository.;
        /// </summary>
        /// <param name="houses">List of House class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> houses);


        /// <summary>
        /// Updates IHouseRepository with an instance of House class against the primary key value.
        /// </summary>
        /// <param name="house">The instance of House class to update.</param>
        /// <param name="houseId">The value of the column "house_id" which will be updated.</param>
        void Update(dynamic house, int houseId);

        /// <summary>
        /// Deletes House from  IHouseRepository against the primary key value.
        /// </summary>
        /// <param name="houseId">The value of the column "house_id" which will be deleted.</param>
        void Delete(int houseId);

        /// <summary>
        /// Produces a paginated result of 10 House classes.
        /// </summary>
        /// <returns>Returns the first page of collection of House class.</returns>
        IEnumerable<Extems.Academic.Entities.House> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 House classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of House class.</returns>
        IEnumerable<Extems.Academic.Entities.House> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IHouseRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of House class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IHouseRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of House class.</returns>
        IEnumerable<Extems.Academic.Entities.House> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IHouseRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of House class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IHouseRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of House class.</returns>
        IEnumerable<Extems.Academic.Entities.House> GetFiltered(long pageNumber, string filterName);



    }
}