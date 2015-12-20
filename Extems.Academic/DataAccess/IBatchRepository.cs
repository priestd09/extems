// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Extems.Academic.DataAccess
{
    public interface IBatchRepository
    {
        /// <summary>
        /// Counts the number of Batch in IBatchRepository.
        /// </summary>
        /// <returns>Returns the count of IBatchRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of Batch. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Batch.</returns>
        IEnumerable<Extems.Academic.Entities.Batch> GetAll();

        /// <summary>
        /// Returns all instances of Batch to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Batch.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the Batch against batchId. 
        /// </summary>
        /// <param name="batchId">The column "batch_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of Batch.</returns>
        Extems.Academic.Entities.Batch Get(int batchId);

        /// <summary>
        /// Gets the first record of Batch.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Batch.</returns>
        Extems.Academic.Entities.Batch GetFirst();

        /// <summary>
        /// Gets the previous record of Batch sorted by batchId. 
        /// </summary>
        /// <param name="batchId">The column "batch_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Batch.</returns>
        Extems.Academic.Entities.Batch GetPrevious(int batchId);

        /// <summary>
        /// Gets the next record of Batch sorted by batchId. 
        /// </summary>
        /// <param name="batchId">The column "batch_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Batch.</returns>
        Extems.Academic.Entities.Batch GetNext(int batchId);

        /// <summary>
        /// Gets the last record of Batch.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Batch.</returns>
        Extems.Academic.Entities.Batch GetLast();

        /// <summary>
        /// Returns multiple instances of the Batch against batchIds. 
        /// </summary>
        /// <param name="batchIds">Array of column "batch_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of Batch.</returns>
        IEnumerable<Extems.Academic.Entities.Batch> Get(int[] batchIds);

        /// <summary>
        /// Custom fields are user defined form elements for IBatchRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for Batch.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding Batch.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for Batch.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of Batch class to IBatchRepository.
        /// </summary>
        /// <param name="batch">The instance of Batch class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic batch, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of Batch class to IBatchRepository.
        /// </summary>
        /// <param name="batch">The instance of Batch class to insert.</param>
        object Add(dynamic batch);

        /// <summary>
        /// Inserts or updates multiple instances of Batch class to IBatchRepository.;
        /// </summary>
        /// <param name="batches">List of Batch class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> batches);


        /// <summary>
        /// Updates IBatchRepository with an instance of Batch class against the primary key value.
        /// </summary>
        /// <param name="batch">The instance of Batch class to update.</param>
        /// <param name="batchId">The value of the column "batch_id" which will be updated.</param>
        void Update(dynamic batch, int batchId);

        /// <summary>
        /// Deletes Batch from  IBatchRepository against the primary key value.
        /// </summary>
        /// <param name="batchId">The value of the column "batch_id" which will be deleted.</param>
        void Delete(int batchId);

        /// <summary>
        /// Produces a paginated result of 10 Batch classes.
        /// </summary>
        /// <returns>Returns the first page of collection of Batch class.</returns>
        IEnumerable<Extems.Academic.Entities.Batch> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 Batch classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of Batch class.</returns>
        IEnumerable<Extems.Academic.Entities.Batch> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IBatchRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of Batch class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IBatchRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of Batch class.</returns>
        IEnumerable<Extems.Academic.Entities.Batch> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IBatchRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of Batch class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IBatchRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of Batch class.</returns>
        IEnumerable<Extems.Academic.Entities.Batch> GetFiltered(long pageNumber, string filterName);



    }
}